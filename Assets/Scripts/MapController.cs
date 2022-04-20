using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
    public static void DrawPolygonCollider(PolygonCollider2D collider) {
        LineRenderer _lr = collider.gameObject.AddComponent<LineRenderer>();
        _lr.startWidth = 0.025f;
        _lr.endWidth = 0.025f;
        _lr.useWorldSpace = false;
        _lr.positionCount = collider.points.Length + 1;
        _lr.sortingOrder = 5;
        
        for (int i = 0; i < collider.points.Length; i++) {
            _lr.SetPosition(i,new Vector3(collider.points[i].x,collider.points[i].y));
        }

        _lr.SetPosition(collider.points.Length, new Vector3(collider.points[0].x, collider.points[0].y));
    }


    // Fr 3.6 10:00

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) { 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if(hit.collider != null) {
                DrawPolygonCollider(hit.collider.gameObject.GetComponent<PolygonCollider2D>());
                Debug.Log (hit.collider.gameObject.name);
            }           
        }
    }
}
