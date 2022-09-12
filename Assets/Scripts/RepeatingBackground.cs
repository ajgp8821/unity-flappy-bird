using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    private void Awake() {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    private void Start() {
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    private void Update() {
        if (transform.position.x < -groundHorizontalLength) {
            RepositionBackground();
        }
    }

    private void RepositionBackground() {
        transform.Translate(Vector2.right * groundHorizontalLength * 2);

        // Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        // transform.position = (Vector2)transform.position + groundOffset;
    }
}
