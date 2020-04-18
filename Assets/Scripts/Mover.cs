using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float trackLength;

    public enum direction {
        Horizontal,
        Vertical
    };

    public direction dir;
    Vector3 relativePosition;
    Vector3 intialPosition;
    LineRenderer lr;
    Camera cam;


    // Start is called before the first frame update
    void Start() {
        intialPosition = transform.position;
        lr = GetComponentInChildren<LineRenderer>();
        cam = Camera.main;
        if (dir == direction.Vertical) {
            lr.SetPosition(0, (Vector3.up * -trackLength) + transform.position);
            lr.SetPosition(1, (Vector3.up * trackLength) + transform.position);
        }
        else {
            lr.SetPosition(0, (Vector3.right * -trackLength) + transform.position);
            lr.SetPosition(1, (Vector3.right * trackLength) + transform.position);
        }
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnMouseDown() {
        relativePosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag() {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (dir == direction.Horizontal) {
            transform.position =
                new Vector3(Mathf.Clamp(mousePos.x, -trackLength + intialPosition.x, trackLength + intialPosition.x),
                    intialPosition.y) - relativePosition;
        }
        else {
            transform.position = new Vector3(intialPosition.x,
                Mathf.Clamp(mousePos.y, -trackLength + intialPosition.y, trackLength + intialPosition.y));
        }
    }
}