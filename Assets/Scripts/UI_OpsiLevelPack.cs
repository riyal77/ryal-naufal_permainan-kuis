using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<UI_OpsiLevelPack, Level_Pack, bool> EventSaatKlik;
    // Start is called before the first frame update
    [SerializeField]
    private Button _tombol = null;

    [SerializeField]
    private TextMeshProUGUI _packName = null;

    [SerializeField]
    private TextMeshProUGUI _labelTerkunci = null;

    [SerializeField]
    private TextMeshProUGUI _labelHarga = null;

    [SerializeField]
    private bool _terkunci = false;

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

    void OnDestroy()
    {
        _tombol.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelPack(Level_Pack levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }

    public void KunciLevelPack()
    {
        _terkunci = true;
        _labelTerkunci.gameObject.SetActive(true);
        _labelHarga.transform.parent.gameObject.SetActive(true);
        _labelHarga.text = $"{_levelPack.Harga}";
    }

    public void BukaLevelPack()
    {
        _terkunci = false;
        _labelTerkunci.gameObject.SetActive(false);
        _labelHarga.transform.parent.gameObject.SetActive(false);
    }

    private void SaatKlik()
    {
        EventSaatKlik?.Invoke(this, _levelPack, _terkunci);
    }
}
