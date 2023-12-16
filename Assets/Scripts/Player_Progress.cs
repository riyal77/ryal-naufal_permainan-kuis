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

    [SerializeField]
    private string _startingLevelPackName = string.Empty;

    public void simpanProgress()
    {
        if (_progressData.progressLevel == null)
        {
            _progressData.progressLevel = new();
            _progressData.koin = 0;
            _progressData.progressLevel.Add(_startingLevelPackName, 1);
        }

        string dirName = "Temporary";
        
#if UNITY_EDITOR
        string dirPath = Application.dataPath + "/" + dirName;
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        string dirPath = Application.persistentDataPath + "/" + dirName;
#endif
        string filePath = dirPath + "/" + fileName;
        
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
        //var writer      = new BinaryWriter(fileStream);

        /*writer.Write(_progressData.koin);

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

    public bool muatProgress()
    {
        //Loading players' progress
        string dirName = "Temporary";
        string dirPath = Application.dataPath + "/" + dirName;
        string filePath = dirPath + "/" + fileName;

        var fileStream  = File.Open(filePath, FileMode.OpenOrCreate);
        
        //Load file using BinaryFormatter
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

        //Loads save file using BinaryReader
        /*var reader = new BinaryReader(fileStream);
        try {
            _progressData.koin = reader.ReadInt32();

            if (_progressData.progressLevel == null)
            {
                _progressData.progressLevel = new();
            }
            
            while (reader.PeekChar() != -1)
            {
                var levelPack = reader.ReadString();
                var level     = reader.ReadInt32();
                _progressData.progressLevel.Add(levelPack, level);
                Debug.Log($"{levelPack}, Level {level}");
            }

            reader.Dispose();
            fileStream.Dispose();

            Debug.Log($"Memuat progress berhasil.\nJumlah koin : {_progressData.koin}, Jumlah level : {_progressData.progressLevel.Count}");
            
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);

            reader.Dispose();
            fileStream.Dispose();

            return false;
        }*/
    }
}