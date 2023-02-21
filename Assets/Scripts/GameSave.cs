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

    public int totalScore;

    [Space]
    [Space]
    [Space]
    //Anti typo
    public string _NamaPlayer = "NamaPlayer";
    public string _JenisKelamin = "JenisKelamin";
    public string _Kelas = "Kelas";

    public string _Bab = "Bab";

    public string _ScoreConnectingTheDot = "ScoreConnectingTheDot";
    public string _ScoreSpellingBee = "ScoreSpellingBee";
    public string _ScoreDecisionRun = "ScoreDecisionRun";
    public string _ScorePilihanGanda = "ScorePilihanGanda";



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
