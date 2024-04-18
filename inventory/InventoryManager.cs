using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    private InventoryManager instance;
    [SerializeField] private GameObject inventory_go;
    [SerializeField] private bool inventory_active;
    //[SerializeField] private Inventory inventory_data;

    private void Awake() 
    {
        if (this != instance && instance != null) {
            Destroy(this);
            Debug.Log("Destroyed a repeat inventory manager!");
        }

        instance = this;
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Tab)) OpenInventory();
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(1);
        // if (Input.GetKeyDown(KeyCode.Alpha3)) EquipWeapon(2);
    }

    protected void OpenInventory()
    {
        UIHandler.OpenInventoryGUI();
        TimeManager.stopTime();

    }

    protected void CloseInventory()
    {
        UIHandler.CloseInventoryGUI();
        TimeManager.startTime();
    }

    protected void EquipWeapon(uint index) 
    {
        for (int i = 0; i < inventory_go.transform.childCount; i++)
        {
            GameObject c = inventory_go.transform.GetChild(i).gameObject;
            Weapon weapon = c.GetComponent<Weapon>();
            weapon.is_active = false;
            c.SetActive(false);
        }

        // if (inventory_go.transform.childCount <= index)
        inventory_go.transform.GetChild((int) index).gameObject.SetActive(true);
    }



}
