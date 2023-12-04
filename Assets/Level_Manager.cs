using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    [SerializeField]
    private Level_Pack _soal = null;

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

        if (indexSoal >= _soal._jumlahLevel)
        {
            indexSoal = 0;
        }

        Level_Soal soal = _soal.get_level(indexSoal);

        tempatPertanyaan.setPertanyaan($"Level {indexSoal + 1}", soal.pertanyaan, soal.hint);

        for (int i = 0; i < tempatPilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = tempatPilihanJawaban[i];
            Level_Soal.opsiJawaban opsi = soal._opsiJawaban[i];
            poin.setJawaban(opsi.jawaban, opsi.jawabanBenar);
            //poin.setJawaban(soal.pilihanJawaban[i], soal.jawabanBenar[i]);
        }
    }
}
