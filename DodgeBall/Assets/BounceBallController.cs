using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBallController : MonoBehaviour
{   
    public GameObject player;
    Rigidbody my_Body;
    AudioSource my_Audio;
    public AudioClip bounceSound;
    public AudioClip scoreSound;
    int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        my_Body = GetComponent<Rigidbody>();
        my_Audio = GetComponent<AudioSource>();
        my_Body.velocity = Vector3.up * 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -2)
        {
            Time.timeScale = 0;
            this.transform.position = (new Vector3(0, -1.9f, 0));
            player.GetComponent<BouncyPlayerController>().SetLost();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        my_Audio.PlayOneShot(bounceSound);
    }
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<BouncyPlayerController>().IncreaseScore();
        print(score);
        my_Audio.PlayOneShot(scoreSound);
    }
}
