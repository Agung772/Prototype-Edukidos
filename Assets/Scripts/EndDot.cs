using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDot : MonoBehaviour
{
    public bool berwarnaDiawal;

    public string codeDot;
    public Sprite boxColorDefault;
    Sprite boxColorClear;

    public SpriteRenderer boxColor;
    public GameObject animasiTutupKotak;
    private void Start()
    {
        if (!berwarnaDiawal)
        {
            boxColorClear = boxColor.sprite;
            boxColor.sprite = boxColorDefault;
        }

    }

    public void DotClear()
    {
        if (!berwarnaDiawal)
        {
            boxColor.sprite = boxColorClear;
        }
        animasiTutupKotak.SetActive(true);
    }
}
