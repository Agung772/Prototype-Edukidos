using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDragAndDrop3D : MonoBehaviour
{
    public string warna;
    public bool use, clear;
    public GameObject objectPertama;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<DragAndDrop3D>() && objectPertama == null)
        {
            objectPertama = collision.gameObject;
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

    private void OnCollisionStay(Collision collision)
    {
        print("Ada object");
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<DragAndDrop3D>() && objectPertama.name == collision.gameObject.name)
        {
            objectPertama = null;
            use = false;
            clear = false;
            GameplaySpellingBee.instance.checkTotal--;
            //OnCollisionEnter(collision);
        }
    }

}
