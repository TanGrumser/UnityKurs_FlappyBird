using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
    
    public float sprungkraft = 5f;

    void Update() {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Set the y velocity of the bird.
            rigidbody.velocity = new Vector2(0f, sprungkraft);
        }
    }
}
