using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ListPertanyaan
{
    public Sprite startDot;
    public Sprite EndDot;
}
public class GameplayConnectingTheDot : MonoBehaviour
{
    public static GameplayConnectingTheDot instance;
    public int batrai = 3;
    public int bab;

    public GameObject batraiUI;

    public List<ListPertanyaan> listPertanyaanBab1;

    DotController[] dotController;
    EndDot[] endDot;


    private void Awake()
    {
        instance = this;
        dotController = FindObjectsOfType<DotController>();
        endDot = FindObjectsOfType<EndDot>();

        //Random color di Dot
        RandomSD();
        RandomED();
    }

    private void Start()
    {
        bab = GameManager.instance.GameSave.bab;

        if (bab == 1)
        {
            for (int i = 0; i < dotController.Length; i++)
            {
                if (i == 0) dotController[randomSD].boxGambar.sprite = listPertanyaanBab1[0].startDot;
                else if (i == 1) dotController[randomSD].boxGambar.sprite = listPertanyaanBab1[1].startDot;
                else if (i == 2) dotController[randomSD].boxGambar.sprite = listPertanyaanBab1[2].startDot;
                else if (i == 3) dotController[randomSD].boxGambar.sprite = listPertanyaanBab1[3].startDot;
                else if (i == 4) dotController[randomSD].boxGambar.sprite = listPertanyaanBab1[4].startDot;
                else if (i == 5) dotController[randomSD].boxGambar.sprite = listPertanyaanBab1[5].startDot;
            }
        }
    }


    public void ChechDot()
    {
        int checkDot = 0;
        for (int i = 0; i < dotController.Length; i++)
        {
            if (dotController[i].clear) checkDot++;
        }
        if (checkDot == dotController.Length)
        {
            if (batrai == 3)
            {
                ButtonManager.instance.SpawnScoreUI("Hebat!", batrai);
            }
            else if (batrai == 2)
            {
                ButtonManager.instance.SpawnScoreUI("Keren!", batrai);
            }
            else if (batrai == 1)
            {
                ButtonManager.instance.SpawnScoreUI("Baik!", batrai);
            }
        }
    }
    public void SalahDot()
    {
        batrai--;

        if (batrai == 2)
        {
            batraiUI.transform.GetChild(3).gameObject.SetActive(true);
            batraiUI.transform.GetChild(4).gameObject.SetActive(true);
            batraiUI.transform.GetChild(5).gameObject.SetActive(false);
        }
        else if (batrai == 1)
        {
            batraiUI.transform.GetChild(3).gameObject.SetActive(true);
            batraiUI.transform.GetChild(4).gameObject.SetActive(false);
            batraiUI.transform.GetChild(5).gameObject.SetActive(false);
        }
        else if (batrai == 0)
        {
            batraiUI.transform.GetChild(3).gameObject.SetActive(false);
            batraiUI.transform.GetChild(4).gameObject.SetActive(false);
            batraiUI.transform.GetChild(5).gameObject.SetActive(false);

            ButtonManager.instance.SpawnScoreUI("Coba Lagi!", batrai);

        }

    }

    //Random Start Dot
    int randomSD;
    bool[] randomSDBool;
    void RandomSD()
    {
        randomSDBool = new bool[dotController.Length];
        for (int i = 0; i < randomSDBool.Length; i++)
        {
            RandomSDVoid();
            if (i == 0) dotController[randomSD].color = "red";
            else if (i == 1) dotController[randomSD].color = "green";
            else if (i == 2) dotController[randomSD].color = "blue";
            else if (i == 3) dotController[randomSD].color = "yellow";
            else if (i == 4) dotController[randomSD].color = "orange";
            else if (i == 5) dotController[randomSD].color = "yo ndak tau";
        }

        void RandomSDVoid()
        {
            randomSD = Random.Range(0, randomSDBool.Length);
            if (randomSD == 0 && !randomSDBool[0]) randomSDBool[0] = true;
            else if (randomSD == 1 && !randomSDBool[1]) randomSDBool[1] = true;
            else if (randomSD == 2 && !randomSDBool[2]) randomSDBool[2] = true;
            else if (randomSD == 3 && !randomSDBool[3]) randomSDBool[3] = true;
            else if (randomSD == 4 && !randomSDBool[4]) randomSDBool[4] = true;
            else if (randomSD == 5 && !randomSDBool[5]) randomSDBool[5] = true;
            else RandomSDVoid();

        }
    }

    //Random Start Dot
    int randomED;
    bool[] randomEDBool;
    void RandomED()
    {
        randomEDBool = new bool[endDot.Length];
        for (int i = 0; i < randomEDBool.Length; i++)
        {
            RandomEDVoid();
            if (i == 0) endDot[randomED].color = "red";
            else if (i == 1) endDot[randomED].color = "green";
            else if (i == 2) endDot[randomED].color = "blue";
            else if (i == 3) endDot[randomED].color = "yellow";
            else if (i == 4) endDot[randomED].color = "orange";
            else if (i == 5) endDot[randomED].color = "yo ndak tau";

        }

        void RandomEDVoid()
        {
            print(randomED);
            randomED = Random.Range(0, randomEDBool.Length);
            if (randomED == 0 && !randomEDBool[0]) randomEDBool[0] = true;
            else if (randomED == 1 && !randomEDBool[1]) randomEDBool[1] = true;
            else if (randomED == 2 && !randomEDBool[2]) randomEDBool[2] = true;
            else if (randomED == 3 && !randomEDBool[3]) randomEDBool[3] = true;
            else if (randomED == 4 && !randomEDBool[4]) randomEDBool[4] = true;
            else if (randomED == 5 && !randomEDBool[5]) randomEDBool[5] = true;
            else RandomEDVoid();


        }
    }
}
