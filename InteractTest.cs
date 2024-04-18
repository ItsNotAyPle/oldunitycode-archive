using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractTest : MonoBehaviour
{
    InteractableObject ihandler;


    public void Start() 
    {
        ihandler = gameObject.GetComponent<InteractableObject>();
        ihandler.on_interact.AddListener(OnInteractActivated);
    }

    public void OnInteractActivated() 
    {
        Renderer r = gameObject.GetComponent<Renderer>();

        if (r.material.color == Color.red)
            r.material.color = Color.white;
        else 
            r.material.color = Color.red; 
    }
}
