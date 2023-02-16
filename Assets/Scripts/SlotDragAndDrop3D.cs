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

            if (other.GetComponent<DragAndDrop3D>().up)
            {
                print(other.gameObject.name);
                other.GetComponent<DragAndDrop3D>().up = false;
                GameplaySpellingBee.instance.CheckDragAndDrop3D();
                print("CheckDrag");
                use1x = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<DragAndDrop3D>() && use1x)
        {
            use = false;
            use1x = false;
            clear = false;
            GameplaySpellingBee.instance.checkTotal--;
        }
    }

}
