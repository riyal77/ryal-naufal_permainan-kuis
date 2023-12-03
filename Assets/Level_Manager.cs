using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    [System.Serializable]
    public struct DataSoal
    {
        public string pertanyaan;
        public Sprite hint;

        public string[] pilihanJawaban;
        public bool[] jawabanBenar;
    }

    [SerializeField]
    private DataSoal[] _soal = new DataSoal[0];

    [SerializeField]
    private UI_Pertanyaan tempatPertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] tempatPilihanJawaban = new UI_PoinJawaban[0];

    private int indexSoal = -1;

    void Start()
    {
        NewLevel();
    }

    public void NewLevel()
    {
        indexSoal++;

        if (indexSoal >= _soal.Length)
        {
            indexSoal = 0;
        }

        DataSoal soal = _soal[indexSoal];

        tempatPertanyaan.setPertanyaan(soal.pertanyaan, soal.hint);

        for (int i = 0; i < tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = tempatPilihanJawaban[i];
            poin.setJawaban(soal.pilihanJawaban[i], soal.jawabanBenar[i]);
        }
    }
}
