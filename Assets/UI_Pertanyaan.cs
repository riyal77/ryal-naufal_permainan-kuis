using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Utility : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text = null;

    [SerializeField]
    private bool _answer = false;

    public void pilihJawaban()
    {
        Debug.Log($"Jawaban anda adalah {_text.text} (_answer))");
    }
}
