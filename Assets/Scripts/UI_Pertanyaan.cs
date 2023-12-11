using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tempatLevel = null;
    [SerializeField]
    private TextMeshProUGUI tempatTeks = null;
    [SerializeField]
    private Image tempatGambar = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Isi tempat text yaitu ");
        Debug.Log(tempatTeks.text);
    }

    public void setPertanyaan(string level, string textPertanyaan, Sprite petunjukGambar)
    {
        tempatGambar.sprite = petunjukGambar;
        tempatTeks.text = textPertanyaan;
        tempatLevel.text = level;
    }
}
