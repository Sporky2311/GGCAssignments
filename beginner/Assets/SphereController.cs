using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    float theta = 0;
    float r;
    // Start is called before the first frame update
    void Start()
    {
        r = transform.position.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(theta)*r, 0, Mathf.Cos(theta)*r);
        theta += 0.005f;
    }
}
