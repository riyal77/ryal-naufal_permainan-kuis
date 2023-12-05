using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Aku lupa kakak",
    menuName = "Game Kuis/Player's Progress"
)]
public class Player_Progress : ScriptableObject
{
    [System.Serializable]
    public struct dataUtama
    {
        public int koin;
        public Dictionary<string, int> progressLevel;
    }

    public dataUtama _progressData = new dataUtama();

    [SerializeField]
    private string fileName = "playerprogress.txt";

    public void simpanProgress()
    {
        //Saving players' progress
        _progressData.koin = 200;

        if (_progressData.progressLevel == null)
        {
            _progressData.progressLevel = new();
        }

        _progressData.progressLevel.Add("Level Pack 1", 3);
        _progressData.progressLevel.Add("Level Pack 3", 5);

        string dirName = "Temporary";
        string dirPath = Application.dataPath + "/" + dirName;
        string filePath = Application.dataPath + "/" + dirName + "/" + fileName;
        
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
            Debug.Log(dirName + " folder berhasil dibuat");
        }

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
            Debug.Log(fileName + " file berhasil dibuat");
        }

        //Saves file using BinaryFormatter
        var fileStream  = File.Open(filePath, FileMode.Open);
        var formatter   = new BinaryFormatter();

        fileStream.Flush();
        formatter.Serialize(fileStream, _progressData);
        
        //Saves file using BinaryWriter
        /*var writer      = new BinaryWriter(fileStream);

        writer.Write(_progressData.koin);

        foreach (var i in _progressData.progressLevel)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }*/

        //Closing the stream
        //writer.Dispose();
        fileStream.Dispose();

        //Saves file in text, without BinaryWriter
        /*string isiData = $"Jumlah Koin : {_progressData.koin}\n";

        foreach (var i in _progressData.progressLevel)
        {
            Debug.Log(i);
            isiData += $"{i}\n";
        }

        File.WriteAllText(filePath, isiData);*/
    }

    public void loadProgress()
    {
        //Loading players' progress
    }
}
