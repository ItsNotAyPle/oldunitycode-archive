using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this script should handle most of the games UI behaviour
// the only exception at the moment is the main menu screen
public class UIHandler : MonoBehaviour
{
    // usually the go reference to the gameobject parent of that part of UI
    public static UIHandler instance { get; private set; }

    [Header("Dialog Screen")]
    [SerializeField] private GameObject dialog_screen_go;
    [SerializeField] private GameObject dialog_option_go;
    
    [Header("Pause Screen")]
    [SerializeField] private GameObject pause_screen_go;
    [SerializeField] private Button pause_exit_button;

    [Header("Crosshair")]
    [SerializeField] private GameObject crosshair_go; 

    [Header("Interact")]
    [SerializeField] private GameObject interact_go; 
    public static bool hide_interact_gui = false;

    
    public void Start() 
    {
        pause_exit_button.onClick.AddListener(Game.Exit);
    }

    private void Awake() 
    {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        } 

        instance = this;
    }

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (dialog_screen_go.activeSelf)
            {
                CloseDialogScreen();
                return;
            }

            if (!pause_screen_go.activeSelf) 
            { 
                OpenPauseScreen(); 
            } 
            else 
            {
                ClosePauseScreen(); 
            }
            
        }


    }

    public static void OpenPauseScreen() 
    {
        TimeManager.stopTime();
        Game.ShowMouse();
        HideCrosshair();
        instance.pause_screen_go.SetActive(true);
    }

    public static void ClosePauseScreen() 
    {
        TimeManager.startTime();
        Game.LockMouse();
        ShowCrosshair();
        instance.pause_screen_go.SetActive(false);
    }

    public static void OpenDialogScreen(List<DialogueOption> options) 
    {
        Player.OnEnterDialogMode();
        //TimeManager.stopTime();
        Game.ShowMouse();
        HideCrosshair();

        for (int i = 0; i < options.Count; i++)
        {
            //GameObject option = Instantiate(instance.dialog_option_go, instance.dialog_screen_go.transform);
            //option.transform.GetChild(0);
            
        }

        instance.dialog_screen_go.SetActive(true);        
    }

    public static void CloseDialogScreen() 
    {
        Player.OnExitDialogMode();
        //TimeManager.startTime();
        Game.LockMouse();
        ShowCrosshair();
        instance.dialog_screen_go.SetActive(false);
    }

    public static void ShowCrosshair() 
    {
        instance.crosshair_go.SetActive(true);
    }

    public static void HideCrosshair() 
    {
        instance.crosshair_go.SetActive(false);
    }

    public static void ShowInteractUI() 
    {
        // this if statement is to prevent it being called every frame
        // this is usually meant to be called from a OnMouseOver function
        // just helps out abit on performance though might not be necessary
        // now distance is taken into account.
        if (!instance.interact_go.activeSelf || hide_interact_gui) instance.interact_go.SetActive(true);
    }

    public static void HideInteractUI() 
    {
        instance.interact_go.SetActive(false);
    }

    public static bool IsInteractUIActivated() 
    {
        return instance.interact_go.activeSelf;
    }

    public static void OpenInventoryGUI()
    {

    }

    public static void CloseInventoryGUI() 
    {
        
    }

}
