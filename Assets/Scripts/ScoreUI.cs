using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public GameObject[] bintang;
    public Text tittleText;

    public void CallScoreUI(string textTittle, int jumlahBintang)
    {
        tittleText.text = textTittle;

        if (jumlahBintang == 3)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(true);
            bintang[2].SetActive(true);
        }
        else if (jumlahBintang == 2)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(true);
            bintang[2].SetActive(false);
        }
        else if (jumlahBintang == 1)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(false);
            bintang[2].SetActive(false);
        }
        else if (jumlahBintang == 0)
        {
            bintang[0].SetActive(false);
            bintang[1].SetActive(false);
            bintang[2].SetActive(false);
        }
    }
}
