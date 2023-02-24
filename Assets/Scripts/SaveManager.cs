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
        instance = this;

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
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
