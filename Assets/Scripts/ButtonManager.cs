using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public GameObject optionUI, scoreUI;

    public GameObject settingHomeUI;

    [Space]
    [Space]
    public Text namaPlayer;
    public Text kelas;
    public Text namaKarakter;
    public Text bab;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        namaPlayer.text = "Nama player : " + SaveManager.instance.GameSave.namaPlayer;
        kelas.text = "Kelas : " + SaveManager.instance.GameSave.kelas;
        namaKarakter.text = "Nama karakter : " + SaveManager.instance.GameSave.karakter;
        bab.text = "Bab : " + SaveManager.instance.GameSave.bab;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OptionUI();
        }
        if (Input.GetKeyUp(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();

        }
    }
    public void SettingUI(bool active)
    {
        if (active) settingHomeUI.SetActive(true);
        else if (!active) settingHomeUI.SetActive(false);

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
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(2);
            scoreUI.SetActive(true);
            scoreUI.GetComponent<ScoreUI>().CallScoreUI(jumlahBintang);
        }

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
