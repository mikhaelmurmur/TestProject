using UnityEngine;
using System.Collections;
using AForge.Imaging;
using System.Collections.Generic;
using AForge;
using System.Drawing;

public class GameMech : MonoBehaviour
{


    public GameObject picture_object;

    static AForge.Math.Geometry.SimpleShapeChecker shape_checker = new AForge.Math.Geometry.SimpleShapeChecker();
    static int figure_type = 1;
    public static int score = -1;
    public static int round = 0;
    public static float start_time = 30.0f;
    public static float time;



    public void Awake()
    {
        NewRound();
        Drawing.gm = this;
        picture_object.transform.position = camera.ScreenToWorldPoint(new Vector3(Screen.width - 150, 150,1));
    }


    

    public void NewRound()
    {
        score++;
        GameMech.round++;
        time = start_time - (GameMech.round - 1) * 5.0f;
        figure_type = (int)(Random.value * 100) % 3 + 1;
        Debug.Log(figure_type);
        Debug.Log(figure_type.ToString());
        Texture2D t = (Texture2D)Resources.Load(figure_type.ToString());
        picture_object.GetComponent<SpriteRenderer>().sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
    }


    public static bool IsRightShape(string path_to_screen_shot)
    {
        BlobCounter blobCounter = new BlobCounter();
        Debug.Log("!!!!!!!! " + path_to_screen_shot);

        Bitmap b = new Bitmap(path_to_screen_shot);
        blobCounter.ProcessImage(b);
        Blob[] blobs = blobCounter.GetObjectsInformation();
        Debug.Log(blobs[0].Rectangle);
        int count = 0;
        for (int i = 0, n = blobs.Length; i < n; i++)
        {
            List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
            switch (figure_type)
            {
                case 1:
                    if (shape_checker.IsTriangle(edgePoints))
                    {
                        
                            return true;

                        
                    }
                    break;
                    
                case 2:
                    if (shape_checker.IsCircle(edgePoints))
                    {
                        if (count == 1)
                        {
                            return true;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    break;
                case 3:
                    if (shape_checker.IsQuadrilateral(edgePoints))
                    {
                        if (count == 1)
                        {
                            return true;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    break;
            }
        }
        return false;
    }
}
