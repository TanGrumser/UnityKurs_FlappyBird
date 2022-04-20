using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeinScript : MonoBehaviour {

    public float meineGeschwindigketit = 0.1f;
    public float sprunghöhe = 10f;

    Rigidbody2D rigidbody;
    public LayerMask layerMask;
    int jumps = 2;

    void Start() {
        Debug.Log("Wir zählen jetzt bis 10.");

        int[] block_array = new int[5];

        block_array[0] = 5;
        block_array[1] = 2;
        block_array[2] = 8;
        block_array[3] = 9;
        block_array[4] = 1;

        for (int i = 0; i < 5; i ++) {
            Debug.Log(i);
        }

        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        HandleHroizontalInput();
        HandleVerticalInput();
    }

    void HandleVerticalInput() {
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0) {
            // Give the player velocity in y direction.
            rigidbody.AddForce(Vector2.up * sprunghöhe, ForceMode2D.Impulse);
            jumps--;
        }

        CheckJumps();
    }

    void CheckJumps() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, layerMask);

        if (hit.collider != null && rigidbody.velocity.y <= 0) {
            // Wir haben was mit unseren Füßen berührt und resetten den sprung.
            jumps = 2;
        }
    }

    void HandleHroizontalInput() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            rigidbody.AddForce(Vector2.right * meineGeschwindigketit, ForceMode2D.Force);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.AddForce(Vector2.left * meineGeschwindigketit, ForceMode2D.Force);
        }

        // Wenn wir eine maximalgeschwindigekit erreicht haben wollen wir nicht weiter beschleuigen.
        if (rigidbody.velocity.x > 5) {
            rigidbody.velocity = new Vector2(5, rigidbody.velocity.y);
        } else if (rigidbody.velocity.x < -5) {
            rigidbody.velocity = new Vector2(-5, rigidbody.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Sprungplattform brett = other.GetComponent<Sprungplattform>();

        if (brett != null) {
            float federkraftVonSprungbrett = brett.federkrat;
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(other.transform.up * federkraftVonSprungbrett, ForceMode2D.Impulse);
        }
    }

}
