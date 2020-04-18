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


    void Start() {

        intialPosition = transform.position;
        lr = GetComponentInChildren<LineRenderer>();
        cam = Camera.main;

        //Draw Line
        if (dir == direction.Vertical) {
            lr.SetPosition(0, (Vector3.up * -trackLength) + transform.position);
            lr.SetPosition(1, (Vector3.up * trackLength) + transform.position);
        }
        else {
            lr.SetPosition(0, (Vector3.right * -trackLength) + transform.position);
            lr.SetPosition(1, (Vector3.right * trackLength) + transform.position);
        }
    }

    // Gets position relative to fan
    private void OnMouseDown() {
        relativePosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Moves fan to the cursor
    private void OnMouseDrag() {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (dir == direction.Horizontal) {
            transform.position = new Vector3(Mathf.Clamp(mousePos.x + relativePosition.x, -trackLength + intialPosition.x, trackLength + intialPosition.x), intialPosition.y);
        }
        else {
            transform.position = new Vector3(intialPosition.x, Mathf.Clamp(mousePos.y + relativePosition.y, -trackLength + intialPosition.y, trackLength + intialPosition.y)); ;
        }
    }
}
