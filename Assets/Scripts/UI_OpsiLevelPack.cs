using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<Level_Pack> EventSaatKlik;
    // Start is called before the first frame update
    [SerializeField]
    private Button _tombol = null;

    [SerializeField]
    private TextMeshProUGUI _packName = null;

    [SerializeField]
    private Level_Pack _levelPack = null;

    void Start()
    {
        if (_levelPack != null)
        {
            SetLevelPack(_levelPack);
        }

        _tombol.onClick.AddListener(SaatKlik);
    }

    public void SetLevelPack(Level_Pack levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }

    private void SaatKlik()
    {
        EventSaatKlik?.Invoke(_levelPack);
    }

    void OnDestroy()
    {
        _tombol.onClick.RemoveListener(SaatKlik);
    }
}
