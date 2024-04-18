using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsService : MonoBehaviour
{
    public static void LoadGame()
    {
        AsyncOperation operation =  SceneManager.LoadSceneAsync("Dev");
        if (!operation.isDone)
        {
            float load_progress = operation.progress;
        }

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

    }
}
