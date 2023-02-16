using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDot : MonoBehaviour
{
    public string color;

    private void Start()
    {
        if (color == "red")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (color == "blue")
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (color == "yellow")
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if (color == "green")
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (color == "cyan")
        {
            GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else
        {
            print("Isi warna objectnya cuy");
        }
    }
}
