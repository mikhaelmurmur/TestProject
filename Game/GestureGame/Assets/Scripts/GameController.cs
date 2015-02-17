using UnityEngine;
using System.Collections;




public class GameController : MonoBehaviour
{
    void Awake()
    {
       // DontDestroyOnLoad(this);
    }

    void OnGUI()
    {
        
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 10, 80, 20), "Start"))
            {
                Application.LoadLevel("GameScene");
                DontDestroyOnLoad(GameInfo.Instance);
            }
        
    }

    // Update is called once per frame

}

public class GameInfo : Singleton<GameInfo>
{
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Application.LoadLevel(0);
            Application.CaptureScreenshot("Screen.png");
        }
    }

    public static int level_number = 0;
    public static int scrore = 0;
    public static int delta_time;
    public static int start_time;
}



/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// 
/// As a note, this is made as MonoBehaviour because we need Coroutines.
/// </summary>
