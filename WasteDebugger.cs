using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// waste referring to the name of the game
public class WasteDebugger
{
    public enum DEBUG_LEVEL
    {
        ALL = 1,
        LOW = 2,
        MEDIUM = 3,
        HIGH = 4
    }

    private static int log_level = 0;

    public static void Log(string text, DEBUG_LEVEL level)
    {
        if ((int) level <= log_level)
        {
            Debug.Log(text);
        }
    }

    public static void SetLogLevel(DEBUG_LEVEL level)
    {
        log_level = (int) level;
    }
}
