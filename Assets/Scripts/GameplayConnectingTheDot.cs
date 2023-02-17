using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayConnectingTheDot : MonoBehaviour
{
    public static GameplayConnectingTheDot instance;
    public int batrai = 3;

    public float timeGame = 120, time;

    public GameObject batraiUI;

    public DotController[] dotController;
    public EndDot[] endDot;
    private void Awake()
    {
        instance = this;
        dotController = FindObjectsOfType<DotController>();
        endDot = FindObjectsOfType<EndDot>();
       
    }

    private void Start()
    {
        time = timeGame;


    }

    public void ChechDot()
    {
        int checkDot = 0;
        for (int i = 0; i < dotController.Length; i++)
        {
            if (dotController[i].clear) checkDot++;
        }
        if (checkDot == dotController.Length)
        {
            if (batrai == 3)
            {
                ButtonManager.instance.SpawnScoreUI("Hebat!", batrai);
            }
            else if (batrai == 2)
            {
                ButtonManager.instance.SpawnScoreUI("Keren!", batrai);
            }
            else if (batrai == 1)
            {
                ButtonManager.instance.SpawnScoreUI("Baik!", batrai);
            }
        }
    }
    public void SalahDot()
    {
        batrai--;

        if (batrai == 2)
        {
            batraiUI.transform.GetChild(3).gameObject.SetActive(true);
            batraiUI.transform.GetChild(4).gameObject.SetActive(true);
            batraiUI.transform.GetChild(5).gameObject.SetActive(false);
        }
        else if (batrai == 1)
        {
            batraiUI.transform.GetChild(3).gameObject.SetActive(true);
            batraiUI.transform.GetChild(4).gameObject.SetActive(false);
            batraiUI.transform.GetChild(5).gameObject.SetActive(false);
        }
        else if (batrai == 0)
        {
            batraiUI.transform.GetChild(3).gameObject.SetActive(false);
            batraiUI.transform.GetChild(4).gameObject.SetActive(false);
            batraiUI.transform.GetChild(5).gameObject.SetActive(false);

            ButtonManager.instance.SpawnScoreUI("Coba Lagi!", batrai);

        }

    }
}
