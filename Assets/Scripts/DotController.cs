using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    public bool berwarnaDiawal;

    public string codeDot;
    public Color warnaLine;
    public bool useLine, clear, salah;
    public Transform target;
    public SetPositionEnd setPositionEnd;

    public LineRenderer lineRenderer;
    Vector3 mousePos, startMousePos;
    public Sprite boxColorDefault;
    Sprite boxColorClear;
    public SpriteRenderer boxColor;


    private void Start()
    {


        
        //Set coding warna untuk setPositionEnd
        setPositionEnd.gameObject.GetComponent<SetPositionEnd>().codeDot = codeDot;


        //Mencari target
        EndDot[] endDots = FindObjectsOfType<EndDot>();
        for (int i = 0; i < endDots.Length; i++)
        {
            if (endDots[i].codeDot == codeDot)
            {
                target = endDots[i].gameObject.transform;
            }
        }


        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));


        if (!berwarnaDiawal)
        {
            boxColorClear = boxColor.sprite;
            boxColor.sprite = boxColorDefault;

            lineRenderer.startColor = InputColor.instance.grey;
            lineRenderer.endColor = InputColor.instance.grey;
        }
        else
        {
            lineRenderer.startColor = warnaLine;
            lineRenderer.endColor = warnaLine;
        }


    }
    bool cooldownSfxHoldClick;
    private void Update()
    {
        if (Input.GetMouseButton(0) && useLine)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition - startMousePos);
            lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));

            setPositionEnd.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);


            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
  
                if (!cooldownSfxHoldClick)
                {
                    cooldownSfxHoldClick = true;
                    AudioManager.instance.SfxHoldClick();
                    print("HoldSFX");
                    yield return new WaitForSeconds(0.5f);
                    cooldownSfxHoldClick = false;

                }

            }
        }
    }

    private void OnMouseDown()
    {
        useLine = true;
        startMousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseUp()
    {
        useLine = false;


        if (setPositionEnd.condition == "benar")
        {
            clear = true;
            target.GetComponent<EndDot>().DotClear();
            DotClear();
        }
        else if (setPositionEnd.condition == "salah")
        {
            GameplayConnectingTheDot.instance.SalahDot();

            lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
            lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
            setPositionEnd.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else if (setPositionEnd.condition == "null")
        {
            setPositionEnd.condition = "null";

            lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
            lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
            setPositionEnd.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        GameplayConnectingTheDot.instance.ChechDot();
    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    public void DotClear()
    {
        if (!berwarnaDiawal)
        {
            boxColor.sprite = boxColorClear;

            lineRenderer.startColor = warnaLine;
            lineRenderer.endColor = warnaLine;
        }

    }
}
