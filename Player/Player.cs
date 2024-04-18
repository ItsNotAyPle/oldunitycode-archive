using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }
    public static bool in_dialoge_mode = false;
    public Camera player_camera;
    public FPCHandler camera_handler;

    private Health _health;

    private void Start() 
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Awake() 
    {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        } 

        instance = this;
        instance._health = GetComponent<Health>();
    }


    public static int GetPlayerHealth() 
    {
        return instance._health.GetHealth();
    }

    public static float DistanceFromPlayer(Vector3 objpos) 
    {
        return (float) Vector3.Distance(objpos, instance.transform.position);
    }

    public static List<InventoryItem> GetInventoryItems()
    {
        return new List<InventoryItem>();
    }
    
    public static void OnEnterDialogMode()
    {
        in_dialoge_mode = true;
        instance.camera_handler.enable_camera_movement = false;
        
    }

    public static void OnExitDialogMode()
    {
        in_dialoge_mode = false;
        instance.camera_handler.enable_camera_movement = true;
    }
}
