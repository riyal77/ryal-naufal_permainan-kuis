using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
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
        string fileName = "contoh.txt";
        string path = Application.dataPath + "/" + fileName;

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
            Debug.Log(fileName + " file berhasil dibuat");
        }

        //Saving data into the file
        string _isiData = "Ini hanyalah percobaan";
        File.WriteAllText(path, _isiData);

        Debug.Log("Data tersimpan di " + path);
    }

    public bool muatProgress()
    {
        //Loading players' progress
        string dirName = "Temporary";
        string dirPath = Application.dataPath + "/" + dirName;
        string filePath = dirPath + "/" + fileName;

        var fileStream  = File.Open(filePath, FileMode.Open);
        
        try {
            var formatter   = new BinaryFormatter();

            _progressData = (dataUtama)formatter.Deserialize(fileStream);
            fileStream.Dispose();

            Debug.Log($"Jumlah koin : {_progressData.koin}, {_progressData.progressLevel.Count}");
            return true;
        }
        catch(System.Exception e) {
            Debug.Log($"Gagal nih, {e.Message}");
            
            fileStream.Dispose();
            return false;
        }
    }
}
