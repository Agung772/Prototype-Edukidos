using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurufManager : MonoBehaviour
{
    public int totalHuruf;

    public GameObject hurufPrefab;
    public HurufController[] hurufController;

    int urutanHuruf;
    public float startX;

    public int[] randomClue;
    public int maxClue = 1;

    public Vector3[] positionHuruf;

    private void Awake()
    {
        startX = -0.75f * (totalHuruf - 1);
        print(startX);
        hurufController = new HurufController[totalHuruf];
        positionHuruf = new Vector3[totalHuruf];


        //random clue
        randomClue = new int[totalHuruf];
        for (int i = 0; i < randomClue.Length; i++)
        {
            if (i == 0 || i == totalHuruf - 1)
            {
                randomClue[i] = 1;
            }
            else
            {
                float random = Random.Range(0, 2);
                if (random == 1 && maxClue > 0)
                {
                    maxClue--;
                    randomClue[i] = 1;
                }
                else
                {
                    randomClue[i] = -4;
                }
            }
        }


        for (int i = 0; i < totalHuruf; i++)
        {
            Instantiate(hurufPrefab, transform);
            hurufController[i] = transform.GetChild(i).GetComponent<HurufController>();
            urutanHuruf++;
            hurufController[i].huruf = urutanHuruf.ToString();

            //Set posisi huruf
            hurufController[i].transform.localPosition = new Vector3(startX, randomClue[i], 0);
            positionHuruf[i] = hurufController[i].transform.localPosition;
            startX += 1.5f;
        }
    }

    public void RestartHuruf()
    {
        for (int i = 0; i < totalHuruf; i++)
        {
            hurufController[i].transform.localPosition = positionHuruf[i];
        }

    }
}
