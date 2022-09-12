using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderController : MonoBehaviour {

    private BoxCollider2D boxCollider2d;

    private void Awake() {
        boxCollider2d = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    private void Start() {
        
    }

    // Update is called once per frame
    private void Update() {
        
    }

    private void LateUpdate() {
        if (GameController.gameController.gameOver) {
            boxCollider2d.enabled = false;
        }
    }
}
