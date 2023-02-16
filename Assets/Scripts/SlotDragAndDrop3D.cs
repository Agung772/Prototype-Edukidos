using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDragAndDrop3D : MonoBehaviour
{
    public string warna;
    public bool use, use1x, clear;

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

            if (!other.GetComponent<DragAndDrop3D>().click && !use1x)
            {
                use1x = true;
                GameplaySpellingBee.instance.CheckDragAndDrop3D();
                print("Bersentuhan");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<DragAndDrop3D>())
        {
            use = false;
            clear = false;
            use1x = false;

            if (other.GetComponent<DragAndDrop3D>().click)
            {
                GameplaySpellingBee.instance.checkTotal--;
                GameplaySpellingBee.instance.checkTotal = Mathf.Clamp(GameplaySpellingBee.instance.checkTotal, 0, GameplaySpellingBee.instance.slotDragAndDrop3D.Length);
            }

        }
    }

}
