using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drawing : MonoBehaviour
{

    bool is_pressed = false;
    LineRenderer line_renderer;
    Vector3 tmp_mouse_position;
    void Start()
    {
        tmp_mouse_position = Input.mousePosition;
        line_renderer = GetComponent<LineRenderer>();
        line_renderer.SetWidth(1, 1);
        line_renderer.SetColors(Color.red, Color.red);
    }



    List<Vector3> list_of_segments_of_line = new List<Vector3>();
    public Camera cam;
    void Update()
    {
        if (!is_pressed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tmp_mouse_position = Input.mousePosition;
                is_pressed = true;
                list_of_segments_of_line = new List<Vector3>();
                Vector3 p = cam.ScreenToWorldPoint(Input.mousePosition);
                list_of_segments_of_line.Add(new Vector3(p.x, p.y, 1));
            }
        }
        else
        {
            if ((tmp_mouse_position != Input.mousePosition))
            {
                if (!Input.GetButtonUp("Fire1"))
                {
                    tmp_mouse_position = Input.mousePosition;
                    Vector3 p = cam.ScreenToWorldPoint(Input.mousePosition);
                    list_of_segments_of_line.Add(new Vector3(p.x, p.y, 1));
                    line_renderer = gameObject.GetComponent("LineRenderer") as LineRenderer;
                    int i = 0;
                    line_renderer.SetVertexCount(list_of_segments_of_line.Count);
                    foreach (Vector3 v in list_of_segments_of_line)
                    {
                        line_renderer.SetPosition(i, v);
                        i++;
                    }
                }
                else
                {
                    Debug.Log(Input.GetButtonUp("Fire1"));
                    is_pressed = false;
                }
            }
            else
            {
                if(Input.GetButtonUp("Fire1"))
                {
                    Debug.Log("YES");   
                    is_pressed = false;
                }
            }

        }
    }
}
