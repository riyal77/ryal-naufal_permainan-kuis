using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_OpsiLevelPack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI _packName = null;

    [SerializeField]
    private Level_Pack _levelPack = null;

    void Start()
    {
        if (_levelPack != null)
        {
            SetLevelPack(_levelPack);
        }
    }

    public void SetLevelPack(Level_Pack levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }

}
