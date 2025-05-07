using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

public static class GameManagment
{

    public static void NewGame()
    {
        string path = Application.persistentDataPath + "/player.saveData";
        if (File.Exists(path))
        {
            File.Delete(path);
#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        }

        BinaryFormatter formatter = new BinaryFormatter();
        string path2 = Application.persistentDataPath + "/player.saveData";
        FileStream fs = new FileStream(path2, FileMode.Create);

        GameData data = new GameData();

        formatter.Serialize(fs, data);
        fs.Close();

    }

    public static GameData GetGameData()
    {
        string path = Application.persistentDataPath + "/player.saveData";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;

        }
        else
        {
            return null;
        }
    }
    public static void SaveGame(GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.saveData";
        FileStream fs = new FileStream(path, FileMode.Create);


        formatter.Serialize(fs, gameData);
        fs.Close();
    }
}
