using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    public int codeSave;
    public Text namaPlayer, kelas, jenisKelamin;
    public Button button;

    private void Start()
    {
        LoadTextUI();
    }

    public void LoadTextUI()
    {
        if (codeSave == 0)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().namaPlayer != "")
            {
                namaPlayer.text = "Nama : " + SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().namaPlayer;
                kelas.text = "Kelas : " + SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().kelas;
                jenisKelamin.text = "Karakter : " + SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().karakter;

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }

        }
        else if (codeSave == 1)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().namaPlayer != "")
            {
                namaPlayer.text = "Nama : " + SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().namaPlayer;
                kelas.text = "Kelas : " + SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().kelas;
                jenisKelamin.text = "Karakter : " + SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().karakter;

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
        else if (codeSave == 2)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().namaPlayer != "")
            {
                namaPlayer.text = "Nama : " + SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().namaPlayer;
                kelas.text = "Kelas : " + SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().kelas;
                jenisKelamin.text = "Karakter : " + SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().karakter;

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
        else if (codeSave == 3)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(3).GetComponent<GameSave>().namaPlayer != "")
            {
                namaPlayer.text = "Nama : " + SaveManager.instance.gameObject.transform.GetChild(3).GetComponent<GameSave>().namaPlayer;
                kelas.text = "Kelas : " + SaveManager.instance.gameObject.transform.GetChild(3).GetComponent<GameSave>().kelas;
                jenisKelamin.text = "Karakter : " + SaveManager.instance.gameObject.transform.GetChild(3).GetComponent<GameSave>().karakter;

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
        else
        {
            Debug.LogWarning("Code save belom di ditambah di Load Button");
        }
    }
}
