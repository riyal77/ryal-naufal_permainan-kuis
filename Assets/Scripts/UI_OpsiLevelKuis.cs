using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelKuis : MonoBehaviour
{
    // Start is called before the first frame update
    public static event System.Action<int> EventSaatKlik;
    
    [SerializeField]
    private Button _tombol = null;

    [SerializeField]
    private TextMeshProUGUI _levelName = null;

    [SerializeField]
    private Level_Soal _levelSoal = null;

    public bool TombolInteraksi
    {
        get => _tombol.interactable;
        set => _tombol.interactable = value;
        
    }

    void Start()
    {
        if (_levelSoal != null)
        {
            SetLevelSoal(_levelSoal, _levelSoal.levelIndex);
        }

        _tombol.onClick.AddListener(SaatKlik);
    }

    void OnDestroy()
    {
        _tombol.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelSoal(Level_Soal levelSoal, int index)
    {
        _levelName.text = levelSoal.name;
        _levelSoal = levelSoal;

        _levelSoal.levelIndex = index;
    }

    private void SaatKlik()
    {
        EventSaatKlik?.Invoke(_levelSoal.levelIndex);
    }

}
