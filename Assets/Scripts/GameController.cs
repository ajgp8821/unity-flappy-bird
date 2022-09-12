using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController gameController;

    public GameObject gameOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;

    private int score;
    public Text scoreText;

    private void Awake() {
        if (GameController.gameController == null) {
            GameController.gameController = this;
        }
        else if (GameController.gameController != this) {
            Destroy(gameObject);
            Debug.LogWarning("GameController has been instantiated for the second time. This shouldn't happen.");
        }
    }

    // Update is called once per frame
    private void Update() {
        if (gameOver && Input.GetMouseButtonDown(0)) {
            // SceneManager.LoadScene("main");
            SoundSystem.soundSystem.PlayAudioClip(SoundSystem.soundSystem.swoosh);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void BirdDie() {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    private void OnDestroy() {
        if (GameController.gameController == this) {
            GameController.gameController = null;
        }
    }

    public void BirdScore() {
        if (gameOver)
            return;

        score++;
        scoreText.text = "Score: " + score;
        SoundSystem.soundSystem.PlayAudioClip(SoundSystem.soundSystem.point);
    }
}
