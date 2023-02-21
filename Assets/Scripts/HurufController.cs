using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurufController : MonoBehaviour
{
    public string huruf;
    Vector3 mousePosition;
    public bool up, click;
    public Text hurufText;

    private void Start()
    {
        hurufText.text = huruf;
    }
    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        up = false;
        click = true;
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        up = true;
        click = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        up = false;
    }
}
