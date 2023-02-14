using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDragAndDrop3D : MonoBehaviour
{
    public string warna;
    public bool use, clear;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<DragAndDrop3D>())
        {
            use = true;
            if (warna == collision.collider.GetComponent<DragAndDrop3D>().warna)
            {
                clear = true;
            }
            else
            {
                print("Warnanya salah");
            }
        }

        //Check Gameplay
        GameplaySpellingBee.instance.CheckDragAndDrop3D();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<DragAndDrop3D>())
        {
            use = false;
            clear = false;
            GameplaySpellingBee.instance.checkTotal--;
        }
    }

}
