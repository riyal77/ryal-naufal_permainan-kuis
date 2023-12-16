using TMPro;
using UnityEngine;

public class LevelMenuDataProgress : MonoBehaviour
{
    [SerializeField]
    private Player_Progress playerProgress = null;

    [SerializeField]
    private TextMeshProUGUI textCoin = null;

    [SerializeField]
    private InisialDataGameplay _inisialData = null;
    
    // Start is called before the first frame update
    void Start()
    {
        textCoin.text = $"{playerProgress._progressData.koin}";
    }

        private void OnAppliationQuit()
    {
        _inisialData.SaatKalah = false;
    }
}
