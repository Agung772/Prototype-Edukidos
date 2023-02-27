using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiManager : MonoBehaviour
{
    public static AnimasiManager instance;

    public Animator animasiScreenCTD;

    private void Awake()
    {
        instance = this;
    }

    public void AnimasiScreenCTD(bool condition)
    {
        if (!condition)
        {
            animasiScreenCTD.SetBool("Close", false);
        }
        else
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(4);
                animasiScreenCTD.SetBool("Close", true);
            }

        }
    }
}
