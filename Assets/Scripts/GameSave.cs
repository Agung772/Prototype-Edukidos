using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public string namaPlayer;
    public string jenisKelamin;
    public string kelas;

    public int bab;

    public int scoreConnectingTheDot;
    public int scoreSpellingBee;
    public int scoreDecisionRun;
    public int scorePilihanGanda;

    //Anti typo
    string _NamaPlayer = "NamaPlayer";
    string _JenisKelamin = "JenisKelamin";
    string _Kelas = "Kelas";

    string _Bab = "Bab";

    string _ScoreConnectingTheDot = "ScoreConnectingTheDot";
    string _ScoreSpellingBee = "ScoreSpellingBee";
    string _ScoreDecisionRun = "ScoreDecisionRun";
    string _ScorePilihanGanda = "ScorePilihanGanda";

    public int totalScore;

    private void Awake()
    {
        namaPlayer = PlayerPrefs.GetString(_NamaPlayer);
        jenisKelamin = PlayerPrefs.GetString(_JenisKelamin);
        kelas = PlayerPrefs.GetString(_Kelas);

        bab = PlayerPrefs.GetInt(_Bab);

        scoreConnectingTheDot = PlayerPrefs.GetInt(_ScoreConnectingTheDot);
        scoreSpellingBee = PlayerPrefs.GetInt(_ScoreSpellingBee);
        scoreDecisionRun = PlayerPrefs.GetInt(_ScoreDecisionRun);
        scorePilihanGanda = PlayerPrefs.GetInt(_ScorePilihanGanda);

        totalScore = scoreConnectingTheDot + scoreSpellingBee + scoreDecisionRun + scorePilihanGanda;
    }

    public void SaveProfil(string nama, string jenisKelamin, string kelas)
    {
        PlayerPrefs.SetString(_NamaPlayer, nama);
        PlayerPrefs.SetString(_JenisKelamin, jenisKelamin);
        PlayerPrefs.SetString(_Kelas, kelas);
    }
    public void SaveScoreMiniGame(string namaMiniGame, int score)
    {
        PlayerPrefs.SetInt(namaMiniGame, score);
    }
}
