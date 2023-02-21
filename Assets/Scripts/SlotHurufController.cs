using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHurufController : MonoBehaviour
{
    public string huruf;
    public bool use, use1x, clear;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<HurufController>())
        {
            use = true;

            if (huruf == other.GetComponent<HurufController>().huruf)
            {
                clear = true;
            }
            else
            {
                //print("Warnanya salah");
            }

            if (!other.GetComponent<HurufController>().click && !use1x)
            {
                use1x = true;
                GameplaySpellingBee.instance.CheckHuruf();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<HurufController>())
        {
            use = false;
            clear = false;
            use1x = false;

            if (other.GetComponent<HurufController>().click)
            {
                GameplaySpellingBee.instance.checkTotal--;
                GameplaySpellingBee.instance.checkTotal = Mathf.Clamp(GameplaySpellingBee.instance.checkTotal, 0, GameplaySpellingBee.instance.slotHurufController.Length);
            }

        }
    }

}
