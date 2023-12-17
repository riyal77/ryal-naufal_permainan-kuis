using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PesanKonfirmasiMenu : MonoBehaviour
{
    [SerializeField]
    private Player_Progress playerData = null;

    [SerializeField]
    private GameObject pesanCukupCoin = null;

    [SerializeField]
    private GameObject pesanTakCukupCoin = null;
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

    private void UI_OpsiLevelPack_EventSaatKlik(Level_Pack levelPack, bool terkunci)
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
    }
}
