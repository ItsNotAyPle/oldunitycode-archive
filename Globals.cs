using UnityEngine;


// mainly used for storing prefabs
// TODO: remake this into a refabs class instead

public class Globals : MonoBehaviour
{
    public static Globals instance;
    
    [Tooltip("These are instansiated")]
    [Header("Base models")]
    public GameObject default_npc_model;


    [Header("Particle prefabs")]
    public GameObject blood_splatter_go;
    public GameObject muzzle_flash_go;

    private void Awake() 
    {
        if (this != instance && instance != null) {
            Destroy(this);
            return;
        }

        instance = this;
    }
}