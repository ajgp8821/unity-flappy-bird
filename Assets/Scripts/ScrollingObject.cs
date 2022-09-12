using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start() {
        rb2d.velocity = Vector2.right * GameController.gameController.scrollSpeed;
    }

    // Update is called once per frame
    private void Update() {
        if (GameController.gameController.gameOver) {
            rb2d.velocity = Vector2.zero;
        }
    }
}
