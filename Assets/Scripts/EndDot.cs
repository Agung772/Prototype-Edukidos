using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDot : MonoBehaviour
{
    public string color;

    public SpriteRenderer boxColor;
    public Sprite red, blue, yellow, green, orange;

    private void Start()
    {
        if (color == "red")
        {
            boxColor.sprite = red;
        }
        else if (color == "blue")
        {
            boxColor.sprite = blue;
        }
        else if (color == "yellow")
        {
            boxColor.sprite = yellow;
        }
        else if (color == "green")
        {
            boxColor.sprite = green;
        }
        else if (color == "orange")
        {
            boxColor.sprite = orange;
        }
        else
        {
            print("Isi warna objectnya cuy");
        }
    }
}
