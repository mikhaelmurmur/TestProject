using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drawing : MonoBehaviour
{

    bool is_pressed = false;
    LineRenderer lineRenderer;
    Vector3 tmp_mouse_position;
    void Start()
    {
        tmp_mouse_position = Input.mousePosition;
        lineRenderer = GetComponent<LineRenderer>();
    }

    public GameObject obj;
    List<Vector3> list_of_segments_of_line= new List<Vector3>();
    void Update()
    {
        if (!is_pressed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tmp_mouse_position = Input.mousePosition;
                list_of_segments_of_line.Add(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                lineRenderer = gameObject.GetComponent("LineRenderer") as LineRenderer;
                int i = 0;
                lineRenderer.SetVertexCount(list_of_segments_of_line.Count);
                foreach (Vector3 v in list_of_segments_of_line)
                {
                    lineRenderer.SetPosition(i, v);
                    i++;
                }

                lineRenderer.SetWidth(1, 1);
                lineRenderer.SetColors(Color.red, Color.red);


                //tmp_mouse_position = Input.mousePosition;
                //is_pressed = true;
                //list_of_segments_of_line = new List<Vector3>();
                //list_of_segments_of_line.Add(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            }
        }
        else
        {
            if ((tmp_mouse_position != Input.mousePosition))
            {
                //if (Input.GetButtonDown("Fire1"))
                //{
                
                    //tmp_mouse_position = Input.mousePosition;
                    //list_of_segments_of_line.Add(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                    //lineRenderer = gameObject.GetComponent("LineRenderer") as LineRenderer;
                    //int i = 0;
                    //lineRenderer.SetVertexCount(list_of_segments_of_line.Count);
                    //foreach (Vector3 v in list_of_segments_of_line)
                    //{
                    //    lineRenderer.SetPosition(i, v);
                    //    i++;
                    //}

                    //lineRenderer.SetWidth(1, 1);
                    //lineRenderer.SetColors(Color.red, Color.red);
                //}
                //else
                //{
                //    is_pressed = false;
                //}
            }

        }
    }
}
