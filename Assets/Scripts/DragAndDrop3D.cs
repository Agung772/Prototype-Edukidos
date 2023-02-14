using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop3D : MonoBehaviour
{
    public string warna;
    public Vector3 mousePosition;

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
