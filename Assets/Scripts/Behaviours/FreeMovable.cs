using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovable : GameItem
{

    Camera cam;
    Vector3 relativePos;

    void Start()
    {
        cam = Camera.main;
    }


    private void OnMouseDown() {
        if (!Allowed) return;
        relativePos = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag() {
        if (!Allowed) return;
        Debug.Log(true);
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos + relativePos;
    }
}
