using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameplayPilihanGanda : MonoBehaviour
{
    public static GameplayPilihanGanda instance;

    public int bab;
    public int urutanPertanyaan, benar, salah;

    public Text totalSoalText;
    public GameObject pilihanGandaPrefab;
    public Transform spawnSoal;


    [Serializable]
    public struct ListPertanyaan
    {
        public string pertanyaan;
        public string a, b, c;
    }
    public List<ListPertanyaan> listPertanyaanBab1;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bab = GameManager.instance.GameSave.bab;

        NextPertanyaan();
    }

    //Memunculkan pertanyaan berdasarkan bab
    public void NextPertanyaan()
    {
        urutanPertanyaan++;

        if (bab == 1)
        {
            SpawnPilihanGanda(listPertanyaanBab1[urutanPertanyaan].pertanyaan, 
                listPertanyaanBab1[urutanPertanyaan].a, listPertanyaanBab1[urutanPertanyaan].b, listPertanyaanBab1[urutanPertanyaan].c);
        }

    }

    public void SpawnPilihanGanda(string soal, string jawabanA, string jawabanB, string jawabanC)
    {
        GameObject pilihanGanda = Instantiate(pilihanGandaPrefab, spawnSoal);
        pilihanGanda.GetComponent<PilihanGanda>().SpawnPilihanGanda(soal, jawabanA, jawabanB, jawabanC);
    }
}
