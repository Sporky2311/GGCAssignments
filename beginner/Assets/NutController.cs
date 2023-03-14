using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutController : MonoBehaviour
{
    int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x >= 0.4f)
            dir = -1;
        if (transform.localPosition.x <= -0.4f)
            dir = 1;
            
            transform.Translate(new Vector3(0.1f * dir,0,0));
    }
}
