using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public string namaPlayer;
    public string karakter;
    public string kelas;

    public GameObject homeButton;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public GameObject pilihBabButton;

    public GameObject loadButtonContent;
    public GameObject loadBabContent;


    public void HomeButton(string namaButton)
    {
        homeButton.SetActive(false);
        newGameButton.SetActive(false);
        loadGameButton.SetActive(false);
        pilihBabButton.SetActive(false);

        if (namaButton == "Home") homeButton.SetActive(true);
        else if (namaButton == "NewGame") newGameButton.SetActive(true);
        else if (namaButton == "LoadGame") loadGameButton.SetActive(true);
        else if (namaButton == "PilihBab") pilihBabButton.SetActive(true);
    }

    public void InputNama(string input)
    {
        namaPlayer = input;

        print(namaPlayer);
    }
    public void InputKelas(string input)
    {
        kelas = input;

        print(kelas);
    }
    public void InputJenisKelamin(Dropdown label)
    {
        karakter = label.captionText.text;

        print(karakter);
    }

    //Pembuatan akun / profil baru
    //Ketika load kosong maka akan diisi dengan yang baru dibuat
    public void SaveProfil()
    {
        if (namaPlayer != "" && karakter != "" && kelas != "")
        {
            if (SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().namaPlayer == "")
            {
                SaveManager.instance.GameSave = SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>();
                SaveManager.instance.ChangeCodeSave(0);
                SaveManager.instance.GameSave.SaveProfil(namaPlayer, karakter, kelas);
                HomeButton("PilihBab");

            }
            else if (SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().namaPlayer == "")
            {
                SaveManager.instance.GameSave = SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>();
                SaveManager.instance.ChangeCodeSave(1);
                SaveManager.instance.GameSave.SaveProfil(namaPlayer, karakter, kelas);
                HomeButton("PilihBab");
            }
            else if (SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().namaPlayer == "")
            {
                SaveManager.instance.GameSave = SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>();
                SaveManager.instance.ChangeCodeSave(2);
                SaveManager.instance.GameSave.SaveProfil(namaPlayer, karakter, kelas);
                HomeButton("PilihBab");
            }
            else
            {
                Debug.LogWarning("Penyimpanan full");
            }

            for (int i = 0; i < loadButtonContent.transform.childCount; i++)
            {
                loadButtonContent.transform.GetChild(i).GetComponent<LoadButton>().LoadTextUI();
            }


        }

        //Ada data yang belum diisi
        else
        {
            Debug.LogWarning("Ada data yang belum diisi");
        }


    }

    public void LoadProfil(int codeSave)
    {
        if (codeSave == 0 && SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().namaPlayer != "")
        {
            SaveManager.instance.ChangeCodeSave(0);
            HomeButton("PilihBab");
        }
        else if (codeSave == 1 && SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().namaPlayer != "")
        {
            SaveManager.instance.ChangeCodeSave(1);
            HomeButton("PilihBab");
        }
        else if (codeSave == 2 && SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().namaPlayer != "")
        {
            SaveManager.instance.ChangeCodeSave(2);
            HomeButton("PilihBab");
        }

        for (int i = 0; i < loadBabContent.transform.childCount; i++)
        {
            loadBabContent.transform.GetChild(i).GetComponent<LoadDataBab>().LoadBabText();
        }

    }

    //Untuk pindah bab
    public void SaveBab(int Bab)
    {
        SaveManager.instance.GameSave.SaveBab(Bab);

        ButtonManager.instance.PindahSceneDelay("MetaGame", 2);
    }
}
