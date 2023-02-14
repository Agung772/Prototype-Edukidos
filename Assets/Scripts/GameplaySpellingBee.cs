using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySpellingBee : MonoBehaviour
{
    public static GameplaySpellingBee instance;
    public SlotDragAndDrop3D[] slotDragAndDrop3D;
    public int checkTotal, checkTotalClear;

    private void Awake()
    {
        instance = this;
        slotDragAndDrop3D = FindObjectsOfType<SlotDragAndDrop3D>();
    }

    public void CheckDragAndDrop3D()
    {
        checkTotal = 0;
        for (int i = 0; i < slotDragAndDrop3D.Length; i++)
        {
            if (slotDragAndDrop3D[i].use)
            {
                checkTotal++;
            }
        }

        //Semua slot keisi
        if (slotDragAndDrop3D.Length == checkTotal)
        {
            checkTotalClear = 0;
            for (int i = 0; i < slotDragAndDrop3D.Length; i++)
            {
                if (slotDragAndDrop3D[i].clear)
                {
                    checkTotalClear++;
                }
            }

            //Check benar semua
            if (slotDragAndDrop3D.Length == checkTotalClear)
            {
                print("Udah benar semua cuy");
            }

            //Reset karena salah
            else
            {
                print("gagal, ngulang cuy");
                for (int i = 0; i < slotDragAndDrop3D.Length; i++)
                {
                    slotDragAndDrop3D[i].gameObject.GetComponent<BoxCollider>().isTrigger = true;
                }

                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    yield return new WaitForSeconds(0.5f);
                    for (int i = 0; i < slotDragAndDrop3D.Length; i++)
                    {
                        slotDragAndDrop3D[i].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    }
                }
            }
        }
    }
}
