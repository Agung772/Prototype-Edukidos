using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayConnectingTheDot : MonoBehaviour
{
    public static GameplayConnectingTheDot instance;
    public float timeGame = 120, time;

    public Image timeUI;

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

    private void Update()
    {
        time -= Time.deltaTime;
        timeUI.fillAmount = time / timeGame;
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
            GameManager.instance.NotifTextUI("Tugas Selesai !");
            GameManager.instance.PindahScene("MetaGame", 2);
        }
    }
}
