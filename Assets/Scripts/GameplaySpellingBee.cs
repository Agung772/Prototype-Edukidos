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
        StartCoroutine(CoroutineCheck());
        IEnumerator CoroutineCheck()
        {
            yield return new WaitForSeconds(0.1f);

            //CheckTotal yang ke use dan clear
            checkTotal = 0;
            checkTotalClear = 0;
            for (int i = 0; i < slotDragAndDrop3D.Length; i++)
            {
                if (slotDragAndDrop3D[i].use)
                {
                    checkTotal++;

                }
                if (slotDragAndDrop3D[i].clear)
                {
                    checkTotalClear++;
                }
            }

            //Semua slot keisi
            if (slotDragAndDrop3D.Length == checkTotal)
            {
                //Check benar semua
                if (slotDragAndDrop3D.Length == checkTotalClear)
                {
                    GameManager.instance.NotifTextUI("Tugas Selesai !");
                    GameManager.instance.PindahSceneDelay("MetaGame", 2);
                }

                //Reset karena salah
                else
                {
                    print("gagal, ngulang cuy");
                    for (int i = 0; i < slotDragAndDrop3D.Length; i++)
                    {
                        slotDragAndDrop3D[i].gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    }

                    StartCoroutine(Coroutine());
                    IEnumerator Coroutine()
                    {
                        yield return new WaitForSeconds(0.5f);
                        for (int i = 0; i < slotDragAndDrop3D.Length; i++)
                        {
                            slotDragAndDrop3D[i].gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = false;
                        }
                    }
                }
            }
        }



    }
}
