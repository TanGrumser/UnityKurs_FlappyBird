using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    Animator animatior;
    SpriteRenderer sr;

    void Start() {
        animatior = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {
        Camera.main.orthographicSize += Input.mouseScrollDelta.y;

        if (Camera.main.orthographicSize < 3) {
            Camera.main.orthographicSize = 3;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            sr.flipX = false;
            animatior.Play("Run");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            sr.flipX = true;
            animatior.Play("Run");
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            animatior.Play("Attack");
        }
    }
}
