using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject settingUI;
    public void SettingUI(bool active)
    {
        if (active) settingUI.SetActive(true);
        else if (!active) settingUI.SetActive(false);

    }
}
