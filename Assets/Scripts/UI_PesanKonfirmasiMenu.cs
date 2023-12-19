using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class UI_PesanKonfirmasiMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tempatKoin = null;

    [SerializeField]
    private Player_Progress playerData = null;

    [SerializeField]
    private GameObject pesanCukupCoin = null;

    [SerializeField]
    private GameObject pesanTakCukupCoin = null;

    UI_OpsiLevelPack _tombolLevelPack = null;
    Level_Pack _levelPack = null;
    void Start()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, Level_Pack levelPack, bool terkunci)
    {
        if (!terkunci)
        {
            return;
        }

        gameObject.SetActive(true);

        if (playerData._progressData.koin < levelPack.Harga)
        {
            pesanCukupCoin.SetActive(false);
            pesanTakCukupCoin.SetActive(true);
            return;
        }

        pesanCukupCoin.SetActive(true);
        pesanTakCukupCoin.SetActive(false);

        _tombolLevelPack = tombolLevelPack;
        _levelPack = levelPack;
    }

    public void BukaLevel()
    {
        playerData._progressData.koin -= _levelPack.Harga;
        playerData._progressData.progressLevel[_levelPack.name] = 1;

        tempatKoin.text = $"{playerData._progressData.koin}";
        
        
        playerData.simpanProgress();
        _tombolLevelPack.BukaLevelPack();
    }
}
