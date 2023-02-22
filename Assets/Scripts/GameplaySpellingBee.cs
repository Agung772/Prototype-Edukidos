using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public struct Bab
{
    public GameObject[] soal;
}
public class GameplaySpellingBee : MonoBehaviour
{
    public int bab, urutanSoal;
    public int baterai = 2;
    
    public int checkTotal, checkTotalClear;

    public List<Bab> babList;

    public Text bateraiText;

    public static GameplaySpellingBee instance;
    public SlotHurufController[] slotHurufController;


    private void Awake()
    {
        instance = this;
        slotHurufController = FindObjectsOfType<SlotHurufController>();
    }

    private void Start()
    {
        BateraiUI();

    }

    public void CheckHuruf()
    {
        StartCoroutine(CoroutineCheck());
        IEnumerator CoroutineCheck()
        {
            yield return new WaitForSeconds(0.1f);

            //CheckTotal yang ke use dan clear
            checkTotal = 0;
            checkTotalClear = 0;
            for (int i = 0; i < slotHurufController.Length; i++)
            {
                if (slotHurufController[i].use)
                {
                    checkTotal++;

                }
                if (slotHurufController[i].clear)
                {
                    checkTotalClear++;
                }
            }

            //Semua slot keisi
            if (slotHurufController.Length == checkTotal)
            {
                //Check benar semua
                if (slotHurufController.Length == checkTotalClear)
                {
                    GameManager.instance.NotifTextUI("Tugas Selesai !");
                    GameManager.instance.PindahSceneDelay("MetaGame", 2);
                }

                //Reset karena salah
                else
                {
                    print("gagal, ngulang cuy");
                    //Update untuk UI Baterai
                    baterai--;
                    BateraiUI();

                    for (int i = 0; i < slotHurufController.Length; i++)
                    {
                        slotHurufController[i].gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    }

                    StartCoroutine(Coroutine());
                    IEnumerator Coroutine()
                    {
                        yield return new WaitForSeconds(0.5f);
                        for (int i = 0; i < slotHurufController.Length; i++)
                        {
                            slotHurufController[i].gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = false;
                        }
                    }
                }
            }

            checkTotal = Mathf.Clamp(checkTotal, 0, slotHurufController.Length);
            checkTotalClear = Mathf.Clamp(checkTotalClear, 0, slotHurufController.Length);
        }
    }

    void BateraiUI()
    {
        bateraiText.text = baterai + "/" + 2;
    }
}
