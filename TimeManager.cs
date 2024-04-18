using UnityEngine;

public static class TimeManager 
{
    private static bool time_paused;

    public static void stopTime() 
    {
        Time.timeScale = 0f;
        time_paused = true;
    }

    public static void startTime() 
    {
        Time.timeScale = 1f;
        time_paused = false;
    }

    public static bool isTimePaused() { return time_paused; }

}
