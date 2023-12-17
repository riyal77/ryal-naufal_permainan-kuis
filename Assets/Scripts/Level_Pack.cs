using UnityEngine;

[CreateAssetMenu(
    fileName = "Aku Suka Kamu",
    menuName = "Game Kuis/Level Pack"
)]
public class Level_Pack : ScriptableObject
{
    [SerializeField]
    private Level_Soal[] _isiLevel = new Level_Soal[0];

    [SerializeField]
    private int _harga = 0;
    public int _jumlahLevel => _isiLevel.Length;
    public int Harga => _harga;

    public Level_Soal get_level(int index)
    {
        return _isiLevel[index];
    }
}
