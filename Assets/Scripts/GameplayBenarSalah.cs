using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameplayBenarSalah : MonoBehaviour
{
    public static GameplayBenarSalah instance;

    public int bab;
    public int urutanPertanyaan, benar, salah;

    public Text totalPertanyaanText;
    public GameObject benarSalahPrefab;
    public Transform spawnSoal;


    [Serializable]
    public struct ListPertanyaan
    {
        public string pertanyaan;
        public string jawaban;
    }
    public List<ListPertanyaan> listPertanyaanBab1;
    public List<ListPertanyaan> listPertanyaanBab2;
    public List<ListPertanyaan> listPertanyaanBab3;
    public List<ListPertanyaan> listPertanyaanBab4;
    public List<ListPertanyaan> listPertanyaanBab5;
    public List<ListPertanyaan> listPertanyaanBab6;
    public List<ListPertanyaan> listPertanyaanBab7;
    public List<ListPertanyaan> listPertanyaanBab8;
    public List<ListPertanyaan> listPertanyaanBab9;
    public List<ListPertanyaan> listPertanyaanBab10;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerPrefs.SetInt(SaveManager.instance.GameSave._Bab, 1);

        bab = SaveManager.instance.GameSave.bab;

        NextPertanyaan();
    }
    //Memunculkan pertanyaan berdasarkan bab
    public void NextPertanyaan()
    {
        //Pertanyaan sudah habis 
        //Saving score
        if (urutanPertanyaan == listPertanyaanBab1.Count - 1)
        {
            if (benar == 5) ButtonManager.instance.SpawnScoreUI(3);
            else if (benar == 4) ButtonManager.instance.SpawnScoreUI(3);
            else if (benar == 3) ButtonManager.instance.SpawnScoreUI(2);
            else if (benar == 2) ButtonManager.instance.SpawnScoreUI(2);
            else if (benar == 1) ButtonManager.instance.SpawnScoreUI(1);
            else if (benar == 0) ButtonManager.instance.SpawnScoreUI(0);

        }
        //Next pertanyaan
        else
        {

            if (spawnSoal.childCount != 0)
            {
                Destroy(spawnSoal.GetChild(0).gameObject);
            }

            urutanPertanyaan++;
            totalPertanyaanText.text = urutanPertanyaan + "/" + (listPertanyaanBab1.Count - 1);

            if (bab == 1)
            {
                SpawnBenarSalah(listPertanyaanBab1[urutanPertanyaan].pertanyaan, listPertanyaanBab1[urutanPertanyaan].jawaban);
            }
            else if (bab == 2)
            {
                SpawnBenarSalah(listPertanyaanBab2[urutanPertanyaan].pertanyaan, listPertanyaanBab2[urutanPertanyaan].jawaban);
            }
            else if (bab == 3)
            {
                SpawnBenarSalah(listPertanyaanBab3[urutanPertanyaan].pertanyaan, listPertanyaanBab3[urutanPertanyaan].jawaban);
            }
            else if (bab == 4)
            {
                SpawnBenarSalah(listPertanyaanBab4[urutanPertanyaan].pertanyaan, listPertanyaanBab4[urutanPertanyaan].jawaban);
            }
            else if (bab == 5)
            {
                SpawnBenarSalah(listPertanyaanBab5[urutanPertanyaan].pertanyaan, listPertanyaanBab5[urutanPertanyaan].jawaban);
            }
            else if (bab == 6)
            {
                SpawnBenarSalah(listPertanyaanBab6[urutanPertanyaan].pertanyaan, listPertanyaanBab6[urutanPertanyaan].jawaban);
            }
            else if (bab == 7)
            {
                SpawnBenarSalah(listPertanyaanBab7[urutanPertanyaan].pertanyaan, listPertanyaanBab7[urutanPertanyaan].jawaban);
            }
            else if (bab == 8)
            {
                SpawnBenarSalah(listPertanyaanBab8[urutanPertanyaan].pertanyaan, listPertanyaanBab8[urutanPertanyaan].jawaban);
            }
            else if (bab == 9)
            {
                SpawnBenarSalah(listPertanyaanBab9[urutanPertanyaan].pertanyaan, listPertanyaanBab9[urutanPertanyaan].jawaban);
            }
            else if (bab == 10)
            {
                SpawnBenarSalah(listPertanyaanBab10[urutanPertanyaan].pertanyaan, listPertanyaanBab10[urutanPertanyaan].jawaban);
            }
        }

    }

    public void SpawnBenarSalah(string soal, string jawaban)
    {
        GameObject pilihanGanda = Instantiate(benarSalahPrefab, spawnSoal);
        pilihanGanda.GetComponent<BenarSalah>().SpawnBenarSalah(soal, jawaban);
    }
}
