using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PoinJawaban : MonoBehaviour
{
    public static event Action<string, bool> EventJawabSoal;

    [SerializeField]
    private TextMeshProUGUI _text = null;

    [SerializeField]
    private bool _answer = false;

    public void pilihJawaban()
    {
        EventJawabSoal?.Invoke(_text.text, _answer);
    }

    public void setJawaban(string textJawaban, bool jawabannya)
    {
        _text.text = textJawaban;
        _answer = jawabannya;
    }
}
