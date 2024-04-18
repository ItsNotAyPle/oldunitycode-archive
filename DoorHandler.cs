using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    private void OnMouseOver() 
    {
        UIHandler.ShowInteractUI();
    }

    private void OnMouseExit() 
    {
        UIHandler.HideInteractUI();
    }
}
