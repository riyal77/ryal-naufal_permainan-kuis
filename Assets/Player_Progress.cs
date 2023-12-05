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
        string fileName = "contoh.txt";
        string path = Application.dataPath + "/" + fileName;

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created : " + path);
        }

        //Saving data into the file
        string _isiData = "Ini hanyalah percobaan";
        File.WriteAllText(path, _isiData);

        Debug.Log("Data tersimpan di " + path);
    }

    public void loadProgress()
    {
        //Loading players' progress
    }
}
