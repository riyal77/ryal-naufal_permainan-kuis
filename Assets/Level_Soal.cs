using UnityEngine;

[CreateAssetMenu(
    fileName = "Di manakah",
    menuName = "Game Kuis/Soal Level"
)]
public class Level_Soal : ScriptableObject
{
    [System.Serializable]
    public struct opsiJawaban
    {
        public string jawaban;
        public bool jawabanBenar;
    }
    public string pertanyaan;
    public Sprite hint;

    public opsiJawaban[] _opsiJawaban = new opsiJawaban[0];
}
