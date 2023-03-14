using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    float randomX , randomZ;

    // Start is called before the first frame update
    void Start()
    {   
        randomX = Random.Range(-9.5f, 9.5f);
        randomZ = Random.Range(-9.5f, 9.5f);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.Translate(randomX, 0, randomZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
