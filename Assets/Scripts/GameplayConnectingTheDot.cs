using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayConnectingTheDot : MonoBehaviour
{
    public DotController[] dotController;
    public EndDot[] endDot;
    private void Awake()
    {
        dotController = FindObjectsOfType<DotController>();
        endDot = FindObjectsOfType<EndDot>();
       
    }
}
