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
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(MyCoroutine(goalPosition + Vector3.forward));
        }
    }

    IEnumerator MyCoroutine(Vector3 goalPosition) {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < 100; i++) {
            transform.position = Vector3.Lerp(startPosition, goalPosition, i / 100f);
            yield return new WaitForEndOfFrame();
        }
    }
}
