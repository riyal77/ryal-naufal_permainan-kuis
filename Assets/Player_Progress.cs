using System.Collections.Generic;
using System.IO;
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
    public void simpanProgress()
    {
        //Sampel Data
        _progressData.koin = 200;

        if (_progressData.progressLevel == null)
        {
            _progressData.progressLevel = new();
        }
        _progressData.progressLevel.Add("Level Pack 1", 3);
        _progressData.progressLevel.Add("Level Pack 3", 5);

        string fileName = "playerprogress.txt";
        string dirPath = Application.dataPath + "/Temporary";
        string path =  dirPath + "/" + fileName;

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
            Debug.Log("Folder created : " + dirPath);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created : " + path);
        }

        //Saving data into the file
        string _isiData = $"Jumlah koin : {_progressData.koin}\n";

        foreach (var i in _progressData.progressLevel)
        {
            _isiData += $"{i.Key}, Level {i.Value}\n";
            Debug.Log($"{i.Key}, Level {i.Value}");
        }
        
        File.WriteAllText(path, _isiData);
    }

    public void loadProgress()
    {
        //Loading players' progress
    }
}
