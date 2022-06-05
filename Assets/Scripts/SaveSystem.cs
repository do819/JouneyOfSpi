using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        Player data = new Player(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Player LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player data;
            try
            {
                data = formatter.Deserialize(stream) as Player;
            }
            catch
            {
                data = new Player();
            }

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Can't find path: " + path);

            return null;
        }
    }
}
