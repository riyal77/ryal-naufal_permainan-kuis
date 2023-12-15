using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _inisialData = null;

    [SerializeField]
    private UI_LevelKuisList _kuisList = null;
    
    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack = null;

    [SerializeField]
    private RectTransform _content = null;

    [Space, SerializeField]
    private Level_Pack[] _levelPacks = new Level_Pack[0];
    
    // Start is called before the first frame update
    void Start()
    {
        LoadLevelPack();

        if (_inisialData.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(_inisialData.levelPack);
        }

        //Subscribe event
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void LoadLevelPack()
    {
        foreach(var lp in _levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);
            
            t.SetLevelPack(lp);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

    private void UI_OpsiLevelPack_EventSaatKlik(Level_Pack levelPack)
    {
        _kuisList.gameObject.SetActive(true);
        _kuisList.UnloadLevelPack(levelPack);
        
        gameObject.SetActive(false);

        _inisialData.levelPack = levelPack;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }
}
