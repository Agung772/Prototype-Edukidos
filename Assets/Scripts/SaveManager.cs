using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public int codeLoadSave;

    public GameSave GameSave;

    private void Awake()
    {
        if (SaveManager.instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            print("Delete save manager");
        }





        if (codeLoadSave == 0)
        {
            GameSave = transform.GetChild(0).GetComponent<GameSave>();
        }
        else if (codeLoadSave == 1)
        {
            GameSave = transform.GetChild(1).GetComponent<GameSave>();
        }
        else if (codeLoadSave == 2)
        {
            GameSave = transform.GetChild(2).GetComponent<GameSave>();
        }


    }


    public void ChangeCodeSave(int codeSave)
    {
        codeLoadSave = codeSave;

        if (codeLoadSave == 0)
        {
            GameSave = transform.GetChild(0).GetComponent<GameSave>();
        }
        else if (codeLoadSave == 1)
        {
            GameSave = transform.GetChild(1).GetComponent<GameSave>();
        }
        else if (codeLoadSave == 2)
        {
            GameSave = transform.GetChild(2).GetComponent<GameSave>();
        }
    }

}
