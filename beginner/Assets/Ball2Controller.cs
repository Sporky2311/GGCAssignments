using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2Controller : MonoBehaviour
{
    float theta = 0;
    float r;
    Vector3 v;
    Vector3 oldP, newP;

    // Start is called before the first frame update
    void Start()
    {
        r = transform.position.magnitude;

        oldP = new Vector3(Mathf.Sin(theta) * r, 0, Mathf.Cos(theta) * r);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(Mathf.Sin(theta) * r, 0, Mathf.Cos(theta) * r);
        theta += 0.005f;
        newP = new Vector3(Mathf.Sin(theta) * r, 0, Mathf.Cos(theta) * r);
        v = newP - oldP;

        transform.Translate(v);
        oldP = newP;
        
    }
}