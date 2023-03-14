using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator myAnimator;
    public GameObject ragdollPrefab;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        myAnimator.SetFloat("HAXIS", h);
        myAnimator.SetFloat("VAXIS", v);
    }

    public void die()
    {
        //release the camera
        Camera.main.transform.parent = null; //make camera top level object
        //spawn the ragdoll
        GameObject ragdoll = Instantiate(ragdollPrefab);
        ragdoll.transform.position = transform.position;
        ragdoll.transform.forward = transform.forward;
        Destroy(gameObject);
    }

    
}
