using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _inisialData = null;

    [SerializeField]
    private Player_Progress playerProgress = null;
    
    [SerializeField]
    private Level_Pack _soal = null;

    [SerializeField]
    private UI_Pertanyaan tempatPertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] tempatPilihanJawaban = new UI_PoinJawaban[0];
    
    [SerializeField]
    private GameSceneManager gameSceneManager = null;

    [SerializeField]
    private string sceneMenuLevel;

    private int indexSoal = -1;

    void Start()
    {
        /*if (!playerProgress.muatProgress())
        {
            playerProgress.simpanProgress();
        }*/

        _soal = _inisialData.levelPack;
        indexSoal = _inisialData.levelIndex - 1;

        NewLevel();

        // Subscribe event baru
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void OnAppliationQuit()
    {
        _inisialData.SaatKalah = false;
    }

    public void NewLevel()
    {
        indexSoal++;

        if (indexSoal >= _soal._jumlahLevel)
        {
            gameSceneManager.BukaScene(sceneMenuLevel);
            return;
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

    private void UI_PoinJawaban_EventJawabSoal(string text, bool answer)
    {
        if (answer)
        {
            playerProgress._progressData.koin += 20;
        }
    }
}
