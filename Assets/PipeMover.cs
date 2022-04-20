using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour {

    public float speed = 0.01f;
    
    // Update is called once per frame
    void Update() {
        if (GameManager.isGameRunning) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (transform.position.x < -30) {
            Destroy(gameObject);
        }
    }
}
