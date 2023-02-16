using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop3D : MonoBehaviour
{
    public string warna;
    public Vector3 mousePosition;
    public bool up;

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        up = false;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        up = false;
    }
}
