using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var PuckPos = GameObject.Find("Puck").transform.position;
        this.gameObject.transform.localPosition = new Vector3(PuckPos.x, 0);

        if (PuckPos.z > 1 && this.gameObject.Equals(GameObject.Find("RedDisc")) && transform.position.z > 1.5)
            transform.Translate(PuckPos.x, 0, PuckPos.z);
        else if (PuckPos.z < 1 && this.gameObject.Equals(GameObject.Find("RedDisc")) && transform.position.z < 7)
            transform.Translate(PuckPos.x, 0, 7);
        else if (PuckPos.z < -1 && this.gameObject.Equals(GameObject.Find("BlueDisc")) && transform.position.z < -1.5)
            transform.Translate(PuckPos.x, 0, PuckPos.z);
        else if (PuckPos.z > -1 && this.gameObject.Equals(GameObject.Find("BlueDisc")) && transform.position.z > -7)
            transform.Translate(PuckPos.x, 0, -7);


    }
}
