using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndBoxScript : MonoBehaviour
{

    public GameObject explosion;
    public static int rocksEntered;

    private void Start() {
    }


    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);

        if (other.gameObject.layer == 8) {
            rocksEntered++;
        }
        SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer>();

        var newExplosion = explosion;
        ParticleSystem ps = newExplosion.GetComponent<ParticleSystem>();
        var col = ps.colorOverLifetime;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(sr.color, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        col.color = grad;
        Instantiate(newExplosion, other.gameObject.transform);
        other.attachedRigidbody.Sleep();
        Destroy(other);
    }
}
