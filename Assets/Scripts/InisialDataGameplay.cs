using UnityEngine;

[CreateAssetMenu(
    fileName = "Inisial Data Gameplay",
    menuName = "Game Kuis/Data Gameplay"
)]
public class InisialDataGameplay : ScriptableObject
{
    public Level_Pack levelPack = null;
    public int levelIndex = 0;

    [SerializeField]
    private bool _saatKalah = false;

    public bool SaatKalah
    {
        get => _saatKalah;
        set => _saatKalah = value;
    }
}
