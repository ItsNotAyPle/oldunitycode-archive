using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game 
{
    public static void Exit() {
        
        Application.Quit();
    }

    public static void ShowMouse() 
    {
        Cursor.lockState = CursorLockMode.Confined; 
        Cursor.visible = true;
    }

    public static void LockMouse() 
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
}
