using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float explodeRadius;
    public float explodeSpeed;


    void OnMouseDown() {
        Explode();
    }

    void Explode() {
        foreach (Collider2D rock in Physics2D.OverlapCircleAll(transform.position, explodeRadius)) {
            if (rock.gameObject.layer != 8) { continue; }
            var rb2d = rock.attachedRigidbody;
            var direction = rock.transform.position - transform.position;
            var hyp = Vector3.Distance(transform.position, rock.transform.position);
            rb2d.AddForce((direction / hyp) * explodeSpeed, ForceMode2D.Impulse);
        }
    }


}
