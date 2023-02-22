using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHurufController : MonoBehaviour
{
    public string codeSlotHuruf;
    public string codeHuruf;
    public bool slotHurufAktif;
    public bool use, clear;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<HurufController>())
        {
            if (codeSlotHuruf == other.GetComponent<HurufController>().codeHuruf && !use && other.GetComponent<HurufController>().up && !other.GetComponent<HurufController>().use)
            {
                clear = true;
            }
            else
            {
                //print("Warnanya salah");
            }

            if (other.GetComponent<HurufController>() && !use && other.GetComponent<HurufController>().up && !other.GetComponent<HurufController>().use)
            {
                use = true;
                other.GetComponent<HurufController>().use = true;
                other.GetComponent<HurufController>().up = false;
                
                codeHuruf = other.GetComponent<HurufController>().codeHuruf;
                GameplaySpellingBee.instance.CheckHuruf();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<HurufController>().codeHuruf == codeHuruf)
        {
            clear = false;
            use = false;
            codeHuruf = null;
            other.GetComponent<HurufController>().use = false;

            if (other.GetComponent<HurufController>().click)
            {
                GameplaySpellingBee.instance.checkTotal--;
                GameplaySpellingBee.instance.checkTotal = Mathf.Clamp(GameplaySpellingBee.instance.checkTotal, 0, GameplaySpellingBee.instance.slotHurufController.Length);
            }

        }
    }

}
