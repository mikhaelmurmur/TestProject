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
    float time;
    bool is_finished = false;

    void Start()
    {
        tmp_mouse_position = Input.mousePosition;
        line_renderer = GetComponent<LineRenderer>();
        line_renderer.SetWidth(2, 2);
        line_renderer.SetColors(Color.red, Color.red);
        time = GameMech.time;
        Debug.Log(time);
    }



    List<Vector3> list_of_segments_of_line = new List<Vector3>();
    public Camera cam;



    bool is_screen_captured = false;

    void OnGUI()
    {
        GUI.Label(new Rect(0, Screen.height - 20, 100, 20), time.ToString());
        GUI.Label(new Rect(300, Screen.height - 20, 100, 20), "Score: " + GameMech.score.ToString());
        if(is_finished)
        {
            GUI.Label(new Rect(400, Screen.height - 20, 200, 20), "GAME OVER! Press 'R' to restart");
        }
    }

    void Update()
    {
        if (is_finished && Input.GetKey(KeyCode.R)) 
        {
            GameMech.score = -1;
            GameMech.round = 0;
            gm.NewRound();
            time = GameMech.time;
            is_finished = false;
            //is_pressed = true; 
            line_renderer = gameObject.GetComponent("LineRenderer") as LineRenderer;
           
            line_renderer.SetVertexCount(0);
            
        }
        if (!is_finished)
        {
            if (is_screen_captured)
            {
                if (File.Exists(Application.dataPath + "/tmp.jpg"))
                {
                    Debug.Log("File exists");
                    is_screen_captured = false;
                    if (GameMech.IsRightShape(Application.dataPath + "/tmp.jpg"))
                    {
                        Debug.Log("YUPI");
                        template_image.GetComponent<SpriteRenderer>().sprite = null;

                        gm.NewRound();
                        time = GameMech.time;
                    }
                    else
                    {
                        Debug.Log("BAD");

                        //gm.NewRound();
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
                    try
                    {
                        if (Input.GetButtonUp("Fire1") && (!is_screen_captured))
                        {
                            if (File.Exists(Application.dataPath + "/tmp.jpg"))
                            {
                                System.Threading.Thread.Sleep(100);
                                File.Delete(Application.dataPath + "/tmp.jpg");
                                System.Threading.Thread.Sleep(100);
                            }
                            Application.CaptureScreenshot(Application.dataPath + "/tmp.jpg");
                            is_screen_captured = true;


                            is_pressed = false;
                        }
                    }
                    catch (IOException)
                    {

                        is_pressed = false;
                    }
                }
            }
            if (time < 0)
            {
                //Debug.Log("GameOver");
                is_finished = true;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
    }




}
