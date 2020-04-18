using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    Rigidbody2D rb2d;
    Camera cam;
    float referenceAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var direction = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        referenceAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f - rb2d.rotation;
    }

    private void OnMouseDrag()
    {
        var direction = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        var rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rb2d.rotation = rot - referenceAngle;
    }
}
