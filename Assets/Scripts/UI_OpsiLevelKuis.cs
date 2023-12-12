using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelKuis : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button _tombol = null;

    [SerializeField]
    private TextMeshProUGUI _levelName = null;

    [SerializeField]
    private Level_Soal _levelSoal = null;

    void Start()
    {
        if (_levelSoal != null)
        {
            SetLevelSoal(_levelSoal);
        }

        _tombol.onClick.AddListener(SaatKlik);
    }

    void OnDestroy()
    {
        _tombol.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelSoal(Level_Soal levelSoal)
    {
        _levelName.text = levelSoal.name;
        _levelSoal = levelSoal;
    }

    private void SaatKlik()
    {
        Debug.Log("WKWKWKWK!!!!!!!");
    }

}
