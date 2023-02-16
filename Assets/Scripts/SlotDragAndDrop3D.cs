using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDragAndDrop3D : MonoBehaviour
{
    public string warna;
    public bool use, clear;
    public GameObject objectPertama;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DragAndDrop3D>())
        {

            objectPertama = other.gameObject;
            //Check Gameplay
            GameplaySpellingBee.instance.CheckDragAndDrop3D();

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DragAndDrop3D>())
        {
            use = true;
            if (warna == other.GetComponent<DragAndDrop3D>().warna)
            {
                clear = true;
            }
            else
            {
                //print("Warnanya salah");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<DragAndDrop3D>())
        {
            objectPertama = null;
            use = false;
            clear = false;
            GameplaySpellingBee.instance.checkTotal--;
        }
    }

}
