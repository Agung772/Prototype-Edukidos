using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public ButtonManager buttonManager;
    public GameObject restartUI, quitUI, optionUI;
    bool restart, quit;

    public void RestartUI()
    {
        restartUI.SetActive(true);
        optionUI.SetActive(false);
        restart = true;

    }
    public void QuitUI()
    {
        quitUI.SetActive(true);
        optionUI.SetActive(false);
        quit = true;
    }
    public void No()
    {
        if(restart == true)
        {
            restartUI.SetActive(false);
            optionUI.SetActive(true);
            restart = false;
        }
        if(quit == true)
        {
            quitUI.SetActive(false);
            optionUI.SetActive(true);
            quit = false;
        }

    }
}
