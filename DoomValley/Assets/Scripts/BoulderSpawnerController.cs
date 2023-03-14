using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawnerController : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTime = 3;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<= 0)
        {
            spawn();
            timer = spawnTime;
        }
    }

    void spawn()
    {

        GameObject g = Instantiate(prefab);
        g.transform.position = transform.position;
        g.transform.forward = transform.forward;
    }
}
