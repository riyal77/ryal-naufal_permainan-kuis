using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = null;
    
    [SerializeField]
    private InisialDataGameplay _inisialData = null;

    [SerializeField]
    private UI_LevelKuisList _kuisList = null;
    
    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack = null;

    [SerializeField]
    private RectTransform _content = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_inisialData.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(null, _inisialData.levelPack, false);
        }

        //Subscribe event
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    public void LoadLevelPack(Level_Pack[] levelPack, Player_Progress.dataUtama playerData)
    {
        foreach(var lp in levelPack)
        {
            var t = Instantiate(_tombolLevelPack);
            
            t.SetLevelPack(lp);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            if (!playerData.progressLevel.ContainsKey(lp.name))
            {
                t.KunciLevelPack();
            }
        }
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, Level_Pack levelPack, bool terkunci)
    {
        if (terkunci)
        {
            return;
        }
        //_kuisList.gameObject.SetActive(true);
        _kuisList.UnloadLevelPack(levelPack);
        
        //gameObject.SetActive(false);

        _inisialData.levelPack = levelPack;

        _animator.SetTrigger("KeLevels");
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }
}
