using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour
{

    public float distance = 10;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = ray.GetPoint(distance);
        transform.position = pos;
	}
}
