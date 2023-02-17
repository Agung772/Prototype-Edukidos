using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum NamaScene
    {
        kosong,
        ConnectingTheDot,
        SpellingBee,
        PilihanGandaCepat,
        DecisionRun,
    }

    public NamaScene namaScene;

    public GameSave GameSave;

    public static GameManager instance;
    public GameObject notifTextUI;
    public OpeningTextMiniGame openingTextMiniGame;
    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        if (namaScene == NamaScene.ConnectingTheDot)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Hubungkan Teks dan Gambarnya!!!");
        }
        else if (namaScene == NamaScene.SpellingBee)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Pilih Jawaban Yang Benar !!!");
        }
    }

    public void NotifTextUI(string text)
    {
        notifTextUI.SetActive(true);
        notifTextUI.transform.GetChild(1).gameObject.GetComponent<Text>().text = text;
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
