using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningTextMiniGame : MonoBehaviour
{
    public static OpeningTextMiniGame instance;
    public Text textOpening;
    bool clickTextKedua;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }
    public void TextOpening(string textKedua)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(3);
            textOpening.text = textKedua;
            clickTextKedua = true;
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown && clickTextKedua)
        {
            gameObject.SetActive(false);
        }
    }
}
