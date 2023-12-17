using TMPro;
using UnityEngine;

public class LevelMenuDataProgress : MonoBehaviour
{
    [SerializeField]
    private UI_LevelPackList levelPackList = null;

    [SerializeField]
    private Player_Progress playerProgress = null;

    [SerializeField]
    private TextMeshProUGUI textCoin = null;

    [SerializeField]
    private InisialDataGameplay inisialData = null;

    [Space, SerializeField]
    private Level_Pack[] levelPacks = new Level_Pack[0];
    
    // Start is called before the first frame update
    void Start()
    {
        if (!playerProgress.muatProgress())
        {
            playerProgress.simpanProgress();
        }

        levelPackList.LoadLevelPack(levelPacks, playerProgress._progressData);

        textCoin.text = $"{playerProgress._progressData.koin}";
    }

        private void OnAppliationQuit()
    {
        inisialData.SaatKalah = false;
    }
}
