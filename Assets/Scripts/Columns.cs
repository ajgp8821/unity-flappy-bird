using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameController.gameController.BirdScore();
        }
    }

}
