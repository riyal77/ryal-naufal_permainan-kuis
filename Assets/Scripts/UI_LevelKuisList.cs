using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField]
    private UI_OpsiLevelKuis _tombolLevel = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private Level_Pack _levelPack = null;
    
    // Start is called before the first frame update
    void Start()
    {
        UnloadLevelPack(_levelPack);
    }

    public void UnloadLevelPack(Level_Pack level_pack)
    {
        for (int i = 0; i < level_pack._jumlahLevel; i++)
        {
            var t = Instantiate(_tombolLevel);
            
            t.SetLevelSoal(level_pack.get_level(i));

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}
