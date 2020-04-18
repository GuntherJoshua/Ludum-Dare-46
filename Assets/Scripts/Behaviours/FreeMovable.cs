using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovable : GameItem
{

    Camera cam;
    Vector3 relativePos;
    Rigidbody2D rb2d;

    void Start()
    {
        cam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void OnMouseDown() {
        if (!Allowed) return;
        relativePos = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag() {
        if (!Allowed) return;
        Debug.Log(true);
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb2d.MovePosition(mousePos + relativePos);
    }
}
