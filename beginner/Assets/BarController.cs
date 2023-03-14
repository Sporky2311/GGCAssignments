using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    int dir = 1;
    float angle = 0;
    float distance = 0;
    float r = 1;
    float step = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == 1)
            angle += step;
        else
            angle -= step;
        if (angle > 360 * 2)
            dir = -1;
        if (angle < 0)
            dir = 1;

        distance = -dir * step / 180 * Mathf.PI;
        transform.Translate(distance, 0, 0, Space.World);
        transform.Rotate(Vector3.up, step, Space.Self);

    }
}
