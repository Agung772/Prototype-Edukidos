using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteract : MonoBehaviour
{
    public static ButtonInteract instance;
    public string NamaScene;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void CallButton()
    {
        SceneManager.LoadScene(NamaScene);
    }

    public void SceneMiniGame(string namaScene)
    {
        NamaScene = namaScene;
    }
}
