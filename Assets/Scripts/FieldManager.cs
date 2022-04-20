using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour {
    
    public GameObject[] blocks;
    
    int[][] field = new int[100][];
    GameObject[][] fieldObjects = new GameObject[100][];
    
    Vector3 lastMousePos;

    // Start is called before the first frame update
    void Start() {
        for (int y = 0; y < field.Length; y++) {
            field[y] = new int[100];
            fieldObjects[y] = new GameObject[100];

            for (int x = 0; x < field[y].Length; x++) {
                field[y][x] = Random.Range(-1, 4);

                if (field[y][x] >= 0) {
                    fieldObjects[y][x] = Instantiate(blocks[field[y][x]], new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }

    void Update() {
        Vector3 coordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            int x = (int)Mathf.Round(coordinate.x);
            int y = (int)Mathf.Round(coordinate.y);

            field[y][x] = -1;
            Destroy(fieldObjects[y][x]);
            lastMousePos = coordinate;
        }

        if (Input.GetMouseButton(0)) {
            Vector3 delta = lastMousePos - coordinate;
            Camera.main.transform.position += delta;
            
            coordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePos = coordinate;
        }
    }

}
