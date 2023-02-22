using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    public string codeDot;
    public Color warnaLine;
    public bool useLine, clear, salah;
    public Transform target;
    public SetPositionEnd setPositionEnd;

    public LineRenderer lineRenderer;
    Vector3 mousePos, startMousePos;

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

        
        lineRenderer.startColor = warnaLine;
        lineRenderer.endColor = warnaLine;

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && useLine)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition - startMousePos);
            lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));

            setPositionEnd.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

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
}
