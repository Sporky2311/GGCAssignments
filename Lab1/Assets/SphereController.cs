using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y >= 0.7)
            dir = -1;
        if (transform.localPosition.y <= -0.7)
            dir = 1;
        
        transform.Translate(new Vector3(0,0, 0.05f * dir));
    }
}
