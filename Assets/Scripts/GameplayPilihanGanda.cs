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

    public Text totalPertanyaanText;
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
        PlayerPrefs.SetInt(GameManager.instance.GameSave._Bab, 1);

        bab = GameManager.instance.GameSave.bab;

        NextPertanyaan();
    }
    //Memunculkan pertanyaan berdasarkan bab
    public void NextPertanyaan()
    {
        //Pertanyaan sudah habis 
        //Saving score
        if (urutanPertanyaan == listPertanyaanBab1.Count - 1)
        {
            if (benar == 5) ButtonManager.instance.SpawnScoreUI("Kamu menjawab semua soal dengan benar", 3);
            else if (benar == 4) ButtonManager.instance.SpawnScoreUI("Kamu benar 4 dari 5 soal", 3);
            else if (benar == 3) ButtonManager.instance.SpawnScoreUI("Kamu benar 3 dari 5 soal", 2);
            else if (benar == 2) ButtonManager.instance.SpawnScoreUI("Kamu benar 2 dari 5 soal", 2);
            else if (benar == 1) ButtonManager.instance.SpawnScoreUI("Kamu benar 1 dari 5 soal", 1);
            else if (benar == 0) ButtonManager.instance.SpawnScoreUI("Kamu benar 0 dari 5 soal", 0);

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
                SpawnPilihanGanda(listPertanyaanBab1[urutanPertanyaan].pertanyaan,
                    listPertanyaanBab1[urutanPertanyaan].a, listPertanyaanBab1[urutanPertanyaan].b, listPertanyaanBab1[urutanPertanyaan].c);
            }
            else if (bab == 2)
            {

            }

        }

    }

    public void SpawnPilihanGanda(string soal, string jawabanA, string jawabanB, string jawabanC)
    {
        GameObject pilihanGanda = Instantiate(pilihanGandaPrefab, spawnSoal);
        pilihanGanda.GetComponent<PilihanGanda>().SpawnPilihanGanda(soal, jawabanA, jawabanB, jawabanC);
    }
}
