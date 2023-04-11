using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedFusedController : MonoBehaviour
{
    float fuseTop = 1f;
    float fuseProgress;
    float fuseMidpoint;
    public GameObject litFuse;
    public bool halt = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!halt)
        {
            fuseProgress = litFuse.transform.localPosition.y;
            fuseMidpoint = ((fuseProgress + (1.01f - fuseProgress)/2));
            transform.localPosition = new Vector3(0, fuseMidpoint, 0);
            transform.localScale = new Vector3(transform.localScale.x , (1 - (fuseProgress))/2, transform.localScale.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "LitFuse")
        {
            halt = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "LitFuse")
        {
            halt = false;
        }
    }
}
