using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float sprintSpeed = 3.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;

    private CharacterController _controller;
    private Vector3 _moveDirection;

    void Start()
    {
        _moveDirection = Vector3.zero;
        _controller = GetComponent<CharacterController>();    
    }

    void Update()
    {
        if (TimeManager.isTimePaused()) return;
        
        float speed = 0.0f;
        if (_controller.isGrounded)
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _moveDirection *= speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _moveDirection.y = jumpSpeed;
        }

        _moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(transform.rotation * _moveDirection * Time.deltaTime);
        
    }
}
