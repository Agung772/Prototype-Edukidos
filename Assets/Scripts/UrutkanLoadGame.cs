using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrutkanLoadGame : MonoBehaviour
{
    public GameObject[] childs;
    public int[] nomorSave;
    private void OnEnable()
    {
        childs = new GameObject[transform.childCount];
        nomorSave = new int[transform.childCount];
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;

            if (childs[i].GetComponent<LoadButton>().nama == "")
            {
                nomorSave[i] = i;
            }
        }

        for (int i = 0; i < childs.Length; i++)
        {

        }
        Debug.LogWarning("Urutkan");
    }


}
