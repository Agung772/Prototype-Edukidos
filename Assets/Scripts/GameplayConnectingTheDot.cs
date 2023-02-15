using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayConnectingTheDot : MonoBehaviour
{
    public float timeGame = 120, time;

    public Image timeUI;

    public DotController[] dotController;
    public EndDot[] endDot;
    private void Awake()
    {
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
}
