using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{

    float speed = 0.5f;
    public GameObject explosionPrefab;
    public float fuseTime = 10f;
    float timer;
    public bool allowExplode;
    // Start is called before the first frame update
    void Start()
    {

        timer = fuseTime;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer < 0)
        {
            if (allowExplode)
            {

                    Destroy(transform.parent.parent.parent.gameObject);
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
        }
        else
        {
            timer -= Time.deltaTime;
            transform.parent.localPosition = Vector3.up * (timer / fuseTime);
        }
    }
}
