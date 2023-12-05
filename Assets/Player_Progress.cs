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
        //Saving players' progress
        _progressData.koin = 200;

        if (_progressData.progressLevel == null)
        {
            _progressData.progressLevel = new();
        }

        _progressData.progressLevel.Add("Level Pack 1", 3);
        _progressData.progressLevel.Add("Level Pack 3", 5);

        string fileName = "playerprogress.txt";
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

        string isiData = $"Jumlah Koin : {_progressData.koin}\n";

        foreach (var i in _progressData.progressLevel)
        {
            Debug.Log(i);
            isiData += $"{i}\n";
        }

        File.WriteAllText(filePath, isiData);
    }

    public void loadProgress()
    {
        //Loading players' progress
    }
}
