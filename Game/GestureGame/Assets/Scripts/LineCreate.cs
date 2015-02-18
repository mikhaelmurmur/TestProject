using UnityEngine;
using System.Collections;

public class LineCreate : MonoBehaviour {

	void Awake()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,Screen.width,60f), new Vector2(0.5f, 0.5f));
        this.gameObject.transform.localScale = new Vector3(10, 5);
    }
}
