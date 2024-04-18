using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public static void OnPlayButtonPressed()
    {
        LevelsService.LoadGame();
        Debug.Log("pressed!");
    }
}
