using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour {
    
    public float sprungkraft = 5f;

    void Update() {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameManager.hasGameStarted = true;

            if (GameManager.isGameRunning == false) {
                // Reload scene
                GameManager.isGameRunning = true;
                GameManager.hasGameStarted = false;
                GameManager.score = 0;
                SceneManager.LoadScene(0);
            }

            rigidbody.gravityScale = 1f;

            // Set the y velocity of the bird.
            if (GameManager.isGameRunning) {
                rigidbody.velocity = new Vector2(0f, sprungkraft);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Game Over");
        
        if (other.tag == "Obstacle") {
            GameManager.isGameRunning = false;
        } else {
            GameManager.score++;
            GameManager.instance.DrawScore();
        }
    }
}
