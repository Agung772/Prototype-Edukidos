using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilihanGanda : MonoBehaviour
{
    public Text soalText;

    public Image[] jawabanImage;
    public Text[] jawabanText;
    public string jawabanYangBenar;

    public void SpawnPilihanGanda(string soal, string jawabanA, string jawabanB, string jawabanC)
    {
        soalText.text = soal;
        jawabanText[0].text = jawabanA;
        jawabanText[1].text = jawabanB;
        jawabanText[2].text = jawabanC;

        int random = Random.Range(0, 3);

        if (random == 0)
        {
            jawabanImage[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-260, -50);
            jawabanImage[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(260, -50);
            jawabanImage[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -220);
        }
        else if (random == 1)
        {
            jawabanImage[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-260, -50);
            jawabanImage[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(260, -50);
            jawabanImage[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -220);
        }
        else if (random == 2)
        {
            jawabanImage[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-260, -50);
            jawabanImage[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(260, -50);
            jawabanImage[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -220);
        }
    }

    public void Button(Image imageButton)
    {
        if (!imageButton.gameObject.GetComponent<ButtonScript>().hasClick)
        {
            for (int i = 0; i < jawabanImage.Length; i++)
            {
                jawabanImage[i].color = Color.white;
                jawabanImage[i].gameObject.GetComponent<ButtonScript>().hasClick = false;
            }

            imageButton.gameObject.GetComponent<ButtonScript>().hasClick = true;
            imageButton.color = InputColor.instance.blue;
        }

        //Benar salah jawaban
        else
        {
            if (imageButton.gameObject.GetComponent<ButtonScript>().jawaban == "A")
            {
                print("Jawabannya benar " + imageButton.gameObject.GetComponent<ButtonScript>().jawaban);
                GameplayPilihanGanda.instance.benar++;
            }
            else
            {
                print("Jawabannya salah " + imageButton.gameObject.GetComponent<ButtonScript>().jawaban);
                GameplayPilihanGanda.instance.salah++;
            }

        }

    }
    public void Jawab(string jawab)
    {
        
    }
}
