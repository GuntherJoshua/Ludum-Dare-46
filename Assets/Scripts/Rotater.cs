using UnityEngine;

public class Rotater : GameItem {
    Rigidbody2D rb2d;
    Camera cam;
    float referenceAngle;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    //Get the angle of the mouse when it's pressed to compare the current angle to 
    private void OnMouseDown() {
        if (!Allowed) return;
        var direction = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        referenceAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f - rb2d.rotation;
    }

    //Compares the angle of the mouse now to when it was clicked it rotates the difference
    private void OnMouseDrag() {
        if (!Allowed) return;
        var direction = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        var rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rb2d.rotation = rot - referenceAngle;
    }
}