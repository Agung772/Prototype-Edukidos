using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    public int codeSave;
    public Text namaPlayer, kelas, jenisKelamin;

    private void Start()
    {
        LoadTextUI();
    }

    public void LoadTextUI()
    {
        if (codeSave == 0)
        {
            namaPlayer.text = "Nama : " + SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().namaPlayer;
            kelas.text = "Kelas : " + SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().kelas;
            jenisKelamin.text = SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().jenisKelamin;
        }
        else if (codeSave == 1)
        {
            namaPlayer.text = "Nama : " + SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().namaPlayer;
            kelas.text = "Kelas : " + SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().kelas;
            jenisKelamin.text = SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().jenisKelamin;
        }
        else if (codeSave == 2)
        {
            namaPlayer.text = "Nama : " + SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().namaPlayer;
            kelas.text = "Kelas : " + SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().kelas;
            jenisKelamin.text = SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().jenisKelamin;
        }
    }
}
