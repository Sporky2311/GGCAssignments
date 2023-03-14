using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody2D myBody;
    SpriteRenderer mySprite;
    public float speed;
    public float jumpheight = 15;
    float v, h;
    GameObject clone;
    bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h > 0) { 
        mySprite.flipX = false;
        myAnimator.SetBool("RUN", true);
        }
        else if (h < 0) {
            mySprite.flipX = true;
            myAnimator.SetBool("RUN", true);
        }
        else if(h==0)
            myAnimator.SetBool("RUN", false);

        float y = myBody.velocity.y;
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
                y = 15;
        }
            myBody.velocity = new Vector2(speed * h, y);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WoodPlat")
        {
            myAnimator.SetBool("FLY", false);
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WoodPlat")
        {
            myAnimator.SetBool("FLY", true);
            grounded = false;
        }
    }



}
