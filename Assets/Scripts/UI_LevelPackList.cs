using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
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
}
