using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    public string color;
    public bool useLine, clear, salah;
    public Transform target;
    public SetPositionEnd setPositionEnd;

    public LineRenderer lineRenderer;
    Vector3 mousePos, startMousePos;


    private void Start()
    {
        //Set coding warna untuk setPositionEnd
        setPositionEnd.gameObject.GetComponent<SetPositionEnd>().color = color;


        //Mencari target
        EndDot[] endDots = FindObjectsOfType<EndDot>();
        for (int i = 0; i < endDots.Length; i++)
        {
            if (endDots[i].color == color)
            {
                target = endDots[i].gameObject.transform;
            }
        }

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));

        //Warna
        if (color == "red")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
        else if (color == "blue")
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            lineRenderer.startColor = Color.blue;
            lineRenderer.endColor = Color.blue;
        }
        else if (color == "yellow")
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
            lineRenderer.startColor = Color.yellow;
            lineRenderer.endColor = Color.yellow;
        }
        else if (color == "green")
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
        else if (color == "cyan")
        {
            GetComponent<MeshRenderer>().material.color = Color.cyan;
            lineRenderer.startColor = Color.cyan;
            lineRenderer.endColor = Color.cyan;
        }
        else
        {
            print("Isi warna objectnya cuy");
        }
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
