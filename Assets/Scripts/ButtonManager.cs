using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject settingUI, pauseUI;
    public void SettingUI(bool active)
    {
        if (active) settingUI.SetActive(true);
        else if (!active) settingUI.SetActive(false);

    }
    public void PauseUI(bool active)
    {
        if (active)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!active)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void PindahScene(string namaScene)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(namaScene);
        }
    }
    public void PindahSceneDelay(string namaScene, float delay)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(namaScene);
        }
    }
}
