using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDot : MonoBehaviour
{
    public string codeDot;
    public Sprite boxColorDefault;
    Sprite boxColorClear;

    public SpriteRenderer boxColor;
    private void Start()
    {
        boxColorClear = boxColor.sprite;
        boxColor.sprite = boxColorDefault;
    }

    public void DotClear()
    {
        boxColor.sprite = boxColorClear;
    }
}
