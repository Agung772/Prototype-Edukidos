using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public GameObject settingUI, optionUI, scoreUI;


    private void Awake()
    {
        instance = this;
    }
    public void SettingUI(bool active)
    {
        if (active) settingUI.SetActive(true);
        else if (!active) settingUI.SetActive(false);

    }

    bool option;
    public void OptionUI()
    {
        if (!option)
        {
            optionUI.SetActive(true);
            option = true;
        }
        else if (option)
        {
            optionUI.SetActive(false);
            option = false;
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void SpawnScoreUI(int jumlahBintang)
    {
        scoreUI.SetActive(true);
        scoreUI.GetComponent<ScoreUI>().CallScoreUI(jumlahBintang);
    }

    public bool nextPertanyaan;
    public void NextPertanyaanPilihanGanda()
    {
        if (nextPertanyaan)
        {
            nextPertanyaan = false;
            GameplayPilihanGanda.instance.NextPertanyaan();
        }

    }
}
