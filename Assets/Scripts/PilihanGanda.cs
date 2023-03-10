using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PilihanGanda : MonoBehaviour
{
    public bool sudahDijawab;
    public TextMeshProUGUI soalTextPro;

    public Image[] jawabanImage;
    public TextMeshProUGUI[] jawabanText;

    public void SpawnPilihanGanda(string soal, string jawabanA, string jawabanB, string jawabanC)
    {
        soalTextPro.text = soal;
        jawabanText[0].text = jawabanA;
        jawabanText[1].text = jawabanB;
        jawabanText[2].text = jawabanC;

        int random = Random.Range(0, 3);

        if (random == 0)
        {
            jawabanImage[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-550, -287);
            jawabanImage[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(550, -287);
            jawabanImage[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -287);
        }
        else if (random == 1)
        {
            jawabanImage[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-550, -287);
            jawabanImage[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(550, -287);
            jawabanImage[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -287);
        }
        else if (random == 2)
        {
            jawabanImage[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-550, -287);
            jawabanImage[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(550, -287);
            jawabanImage[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -287);
        }
    }

    public void ClickButton(GameObject button)
    {
        if (sudahDijawab) return;

        if (!button.GetComponent<ButtonScript>().hasClick)
        {
            for (int i = 0; i < jawabanImage.Length; i++)
            {
                jawabanImage[i].color = InputColor.instance.blueButtonPG;
                jawabanImage[i].gameObject.GetComponent<ButtonScript>().hasClick = false;
            }

            button.GetComponent<ButtonScript>().hasClick = true;
            button.GetComponent<Image>().color = InputColor.instance.orange;
        }

        //Benar salah jawaban
        else
        {
            if (button.GetComponent<ButtonScript>().jawaban == "A")
            {
                button.GetComponent<Image>().color = InputColor.instance.green;
                GameplayPilihanGanda.instance.benar++;
            }
            else
            {
                button.GetComponent<Image>().color = InputColor.instance.red;
                GameplayPilihanGanda.instance.salah++;
            }

            sudahDijawab = true;
            ButtonManager.instance.nextPertanyaanPilihanGanda = true;
        }

    }
}
