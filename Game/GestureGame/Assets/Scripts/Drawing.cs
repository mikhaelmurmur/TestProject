using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class Drawing : MonoBehaviour
{

    bool is_pressed = false;
    LineRenderer line_renderer;
    Vector3 tmp_mouse_position;
    public GameObject template_image;
    public static GameMech gm;

    void Start()
    {
        tmp_mouse_position = Input.mousePosition;
        line_renderer = GetComponent<LineRenderer>();
        line_renderer.SetWidth(2, 2);
        line_renderer.SetColors(Color.red, Color.red);
    }



    List<Vector3> list_of_segments_of_line = new List<Vector3>();
    public Camera cam;



    bool is_screen_captured = false;



    void Update()
    {
        if(is_screen_captured)
        {
            if (File.Exists(Application.dataPath + "/tmp.jpg"))
            {
                template_image.GetComponent<SpriteRenderer>().sprite = null;   
                is_screen_captured = false;
                if (GameMech.IsRightShape(Application.dataPath + "/tmp.jpg"))
                {
                    Debug.Log("YUPI");
                    gm.NewRound();
                }
                else
                {
                    Debug.Log("BAD");

                    gm.NewRound();
                }
            }
            
        }
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

                    is_pressed = false;
                }
            }
            else
            {
                if (Input.GetButtonUp("Fire1")&&(!is_screen_captured))
                {
                     if (File.Exists(Application.dataPath + "/tmp.jpg"))
                    {
                        File.Delete(Application.dataPath + "/tmp.jpg");
                    }
                    Application.CaptureScreenshot("Assets/tmp.jpg");
                    is_screen_captured = true;
                    
                   
                    is_pressed = false;
                }
            }

        }
    }




}
