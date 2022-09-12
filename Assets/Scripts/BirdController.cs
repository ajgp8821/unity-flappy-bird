using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public float maxDownVelocity = -5f;
    public float maxDownAngle = -90f;

    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator animator;

    public int upForce = 200;

    private RotateBird rotateBird;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rotateBird = GetComponent<RotateBird>();
    }


    // Start is called before the first frame update
    private void Start() {
        
    }

    // Update is called once per frame
    private void Update() {
        // Debug.Log("Vel " + rb2d.velocity.y);
        if (isDead) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * upForce);
            animator.SetTrigger("Flap");
            // animator.applyRootMotion = true;
            SoundSystem.soundSystem.PlayAudioClip(SoundSystem.soundSystem.wing);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Debug.Log("Layer: " + collision.collider.gameObject.layer);
        // Debug.Log("Layer: " + LayerMask.NameToLayer("Ground"));

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            if (!isDead) {
                SoundSystem.soundSystem.PlayAudioClip(SoundSystem.soundSystem.hit);
                SoundSystem.soundSystem.PlayAudioClip(SoundSystem.soundSystem.die);
            }
            // rigidbody2D.freezeRotation = false;
            rb2d.velocity = Vector2.zero;
            isDead = true;
            animator.SetTrigger("Die");
            rotateBird.enabled = false;
            Invoke("BirdDie", 1f);
            // Debug.Log("Esta muerto");
        }
    }

    private void BirdDie() {
        GameController.gameController.BirdDie();
    }
}
