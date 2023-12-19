using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_PesanLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator _animator = null;

    [SerializeField]
    private GameObject _menuOpsiMenang = null;

    [SerializeField]
    private GameObject _menuOpsiKalah = null;
    
    [SerializeField]
    private TextMeshProUGUI _tempatPesan = null;

    public string Pesan
    {
        get => _tempatPesan.text;
        set => _tempatPesan.text = value;
    }
    
    private void Awake()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        UI_Timer.EventWaktuHabis += UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        UI_Timer.EventWaktuHabis -= UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void UI_Timer_EventWaktuHabis()
    {
        Pesan = "Waktu Habis";
        gameObject.SetActive(true);

        _menuOpsiMenang.SetActive(false);
        _menuOpsiKalah.SetActive(true);
    }

    private void UI_PoinJawaban_EventJawabSoal(string text, bool answer)
    {
        Pesan = $"Jawaban anda {answer}. (Jawaban: {text})";
        gameObject.SetActive(true);

        if (answer)
        {
            _menuOpsiMenang.SetActive(true);
            _menuOpsiKalah.SetActive(false);
        }
        else
        {
            _menuOpsiMenang.SetActive(false);
            _menuOpsiKalah.SetActive(true);
        }

        _animator.SetBool("Benar", answer);
    }
}
