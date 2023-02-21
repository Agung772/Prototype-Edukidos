using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDot : MonoBehaviour
{
    public string codeDot;

    public Sprite boxColorDefault;

    public SpriteRenderer boxColor;
    private void Start()
    {
        boxColor.sprite = boxColorDefault;
    }
}
