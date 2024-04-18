using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This most likely won't get added though may be a rough sketch of an idea.
// if this was to get implemented then it would be an after thought, main ideas
// for traversing around the map is a train system that the player activates
// after completing a quest
public class VehicleMain : MonoBehaviour
{
    [SerializeField] private GameObject wheel_1;
    [SerializeField] private GameObject wheel_2;
    [SerializeField] private GameObject wheel_3;
    [SerializeField] private GameObject wheel_4;

    [SerializeField] private bool player_in_vehicle;

    [SerializeField] private float current_speed;
    [SerializeField] private uint max_speed;

    void FixedUpdate()
    {
        if (!player_in_vehicle) return;

        if (Input.GetKey(KeyCode.W) && current_speed < max_speed)
        {
            current_speed += 0.1f;
            return;
        }



        current_speed -= 0.2f;

        
    }

    protected void TurnVehicleLeft() 
    {
        // transform.localRotation.SetFromToRotation(transform.localRotation);
    }

        protected void TurnVehicleRight() 
    {
        // transform.localRotation.SetFromToRotation(transform.localRotation);
    }


}
