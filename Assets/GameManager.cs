using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject pipePrefab;
    float counter = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        counter -= Time.deltaTime;

        if (counter < 0f) {
            float height = Random.Range(-1f, 2f);

            Instantiate(pipePrefab, new Vector3(15f, height, 0f), Quaternion.identity);
            counter = 1.5f;
        }
    }
}
