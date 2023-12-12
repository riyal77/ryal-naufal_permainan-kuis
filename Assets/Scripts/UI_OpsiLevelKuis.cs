using TMPro;
using UnityEngine;

public class UI_OpsiLevelKuis : MonoBehaviour
{
    // Start is called before the first frame update
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
    }

    private void SetLevelSoal(Level_Soal levelSoal)
    {
        _levelName.text = levelSoal.name;
        _levelSoal = levelSoal;
    }

}
