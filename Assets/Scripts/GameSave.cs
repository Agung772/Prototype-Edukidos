using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public string NamaPlayer;
    public string JenisKelamin;
    public string Kelas;

    public int ScoreConnectingTheDot;
    public int ScoreSpellingBee;
    public int ScoreDecisionRun;
    public int ScorePilihanGanda;

    public int TotalScore;

    private void Awake()
    {
        NamaPlayer = PlayerPrefs.GetString("NamaPlayer");
        JenisKelamin = PlayerPrefs.GetString("JenisKelamin");
        Kelas = PlayerPrefs.GetString("Kelas");

        ScoreConnectingTheDot = PlayerPrefs.GetInt("ScoreConnectingTheDot");
        ScoreSpellingBee = PlayerPrefs.GetInt("ScoreSpellingBee");
        ScoreDecisionRun = PlayerPrefs.GetInt("ScoreDecisionRun");
        ScorePilihanGanda = PlayerPrefs.GetInt("ScorePilihanGanda");

        TotalScore = ScoreConnectingTheDot + ScoreSpellingBee + ScoreDecisionRun + ScorePilihanGanda;
    }

    public void SaveProfil(string nama, string jenisKelamin, string kelas)
    {
        PlayerPrefs.SetString("NamaPlayer", nama);
        PlayerPrefs.SetString("JenisKelamin", jenisKelamin);
        PlayerPrefs.SetString("Kelas", kelas);
    }
    public void SaveScoreMiniGame(string namaMiniGame, int score)
    {
        PlayerPrefs.SetInt(namaMiniGame, score);
    }
}
