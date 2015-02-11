using UnityEngine;
using System.Collections;

public class Drawing : MonoBehaviour {

    bool is_pressed = false;
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public GameObject obj;
    Vector3 start, finish;
	void Update () 
    {
        if(!is_pressed)
        {
            if(Input.GetMouseButtonDown(0))
            {
                is_pressed = true;
                start = new Vector3(Input.GetAxis("Horizontal")*10, Input.GetAxis("Vertical")*10,0);
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                finish = new Vector3(Input.GetAxis("Horizontal")*10, Input.GetAxis("Vertical")*10,0);
                lineRenderer = gameObject.AddComponent<LineRenderer>();
                lineRenderer.SetPosition(0, start);
                lineRenderer.SetPosition(1, finish);
                lineRenderer.SetWidth(100, 100);
                lineRenderer.SetVertexCount(3);
                lineRenderer.SetColors(Color.red, Color.red);
              //  Gizmos.DrawLine(start, finish);
                start = finish;
            }
            else
            {
                is_pressed = false;
            }
        }
	}
}
