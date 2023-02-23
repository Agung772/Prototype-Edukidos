using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniGame : MonoBehaviour
{

    public enum NamaMiniGame
    {
        ConnectingTheDot,
        SpellingBee,
        PilihanGanda,
        BenarSalah,
    }

    public string namaText;
    public NamaMiniGame namaMiniGame;
    public GameObject textCanva;

    private void Start()
    {
        textCanva.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanva.SetActive(true);
            textCanva.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Tekan Tombol dibawah untuk masuk ke game " + namaText;
            ButtonInteract.instance.gameObject.SetActive(true);
            ButtonInteract.instance.SceneMiniGame(namaMiniGame.ToString());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanva.SetActive(false);
            ButtonInteract.instance.gameObject.SetActive(false);
        }
    }

}
