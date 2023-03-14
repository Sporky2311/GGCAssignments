using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            GameObject g = Instantiate(other.gameObject);
            g.transform.position = new Vector2(Random.Range(-10, 10), 5);
            gameObject.SetActive(false);
    }
}
