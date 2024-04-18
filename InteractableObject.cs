using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// this script should be the main from now on
public class InteractableObject : MonoBehaviour
{
    [Range(0f, 100f)] [SerializeField] private float interact_range = 2f;
    [SerializeField] private bool interacted;
    private bool showing_interact_ui;
    public UnityEvent on_interact;
    private bool disable_ui = false;

    private void Awake()
    {
    }

    private void OnMouseOver()
    {

        // is this code even good? - AyPle 22/05/23 00:24
        if (PlayerInRange() && !disable_ui) 
        {
            UIHandler.ShowInteractUI();
            showing_interact_ui = true;

            if (Input.GetKeyDown(KeyCode.E)) 
            {
                on_interact.Invoke();
                interacted = true;
            } 

            return;
        }

        if (showing_interact_ui)
            UIHandler.HideInteractUI();
            
    }

    private void OnMouseExit()
    {
        UIHandler.HideInteractUI();
        showing_interact_ui = false;
    }

    public bool HasInteracted()
    {
        return this.interacted;
    }
    
    public void DisableShowingUI()
    {
        disable_ui = true;
    }

    public bool PlayerInRange()
    {
        return (Player.DistanceFromPlayer(transform.position) <= interact_range);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, interact_range);
    }
}
