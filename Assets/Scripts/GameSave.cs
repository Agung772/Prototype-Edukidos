using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public int codeSave;

    public string namaPlayer;
    public string jenisKelamin;
    public string kelas;

    public int bab;

    public int scoreConnectingTheDot;
    public int scoreSpellingBee;
    public int scoreBenarSalah;
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
    public string _ScoreBenarSalah = "ScoreBenarSalah";
    public string _ScorePilihanGanda = "ScorePilihanGanda";


    //Type save, Nama savean +/ Bab + Code save;

    private void Awake()
    {
        LoadGameData();
    }

    public void LoadGameData()
    {
        namaPlayer = PlayerPrefs.GetString(_NamaPlayer + codeSave);
        jenisKelamin = PlayerPrefs.GetString(_JenisKelamin + codeSave);
        kelas = PlayerPrefs.GetString(_Kelas + codeSave);

        bab = PlayerPrefs.GetInt(_Bab + codeSave);

        print("Berikut profil kamu " + namaPlayer + ", " + jenisKelamin + ", " + kelas);

        scoreConnectingTheDot = PlayerPrefs.GetInt(_ScoreConnectingTheDot + bab + codeSave);
        scoreSpellingBee = PlayerPrefs.GetInt(_ScoreSpellingBee + bab + codeSave);
        scoreBenarSalah = PlayerPrefs.GetInt(_ScoreBenarSalah + bab + codeSave);
        scorePilihanGanda = PlayerPrefs.GetInt(_ScorePilihanGanda + bab + codeSave);

        totalScore = scoreConnectingTheDot + scoreSpellingBee + scoreBenarSalah + scorePilihanGanda;
    }

    public void SaveProfil(string nama, string jenisKelamin, string kelas)
    {
        PlayerPrefs.SetString(_NamaPlayer + codeSave, nama);
        PlayerPrefs.SetString(_JenisKelamin + codeSave, jenisKelamin);
        PlayerPrefs.SetString(_Kelas + codeSave, kelas);

        LoadGameData();
    }
    public void SaveScoreMiniGame(string namaMiniGame, int score)
    {
        PlayerPrefs.SetInt(namaMiniGame + bab + codeSave, score);

        LoadGameData();
    }
}
