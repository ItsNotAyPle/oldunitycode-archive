using UnityEngine;


// First Person Camera Handler
public class FPCHandler : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;
    private float _xRotation = 0f;
    public bool enable_camera_movement = true;


    void Start()
    {
        Game.LockMouse();     
        UIHandler.ShowCrosshair();  
    }

    void Update()
    {
        if (!enable_camera_movement) return;
        if (TimeManager.isTimePaused()) return;
        
        float mouseX = GetAxisInput("Mouse X");
        float mouseY = GetAxisInput("Mouse Y");

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }

    float GetAxisInput(string name)
    {
        return Input.GetAxis(name) * sensitivity * Time.deltaTime;
    }



}
