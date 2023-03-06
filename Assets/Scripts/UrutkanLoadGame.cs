using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrutkanLoadGame : MonoBehaviour
{
    public GameObject[] childs;
    GameObject[] childsTemp;

    int j;
    private void OnEnable()
    {
        UrutkanLoad();
    }

    public void UrutkanLoad()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.01f);
            j = 0;

            childsTemp = new GameObject[childs.Length];

            for (int i = 0; i < childs.Length; i++)
            {
                if (childs[i].GetComponent<LoadButton>().nama != "")
                {
                    childsTemp[j] = childs[i];
                    j++;
                }
            }

            for (int i = 0; i < childs.Length; i++)
            {
                if (childs[i].GetComponent<LoadButton>().nama == "")
                {
                    childsTemp[j] = childs[i];
                    j++;
                }
            }

            for (int i = 0; i < childs.Length; i++)
            {
                childsTemp[i].transform.SetParent(transform.parent);
            }
            for (int i = 0; i < childs.Length; i++)
            {
                childsTemp[i].transform.SetParent(transform);
            }
        }
    }

}
