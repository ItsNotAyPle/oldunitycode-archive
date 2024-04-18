using System.IO;
using UnityEngine;



public class SaveFileHandler
{
    public class GameSaveFileContents 
    {
        public int level;
        public string player_name;
    }


    // This should always point to a json file for now.
    public GameSaveFileContents ReadSaveFile(string filename) 
    {
        string json_data = File.ReadAllText(filename, System.Text.Encoding.ASCII);
        return JsonUtility.FromJson<GameSaveFileContents>(json_data);

    }

}
