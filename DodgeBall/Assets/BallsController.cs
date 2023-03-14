using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsController : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOver;
    public int ballsNum = 100;
    public float speed = 2.0f;
    float ballStartHeight = 15.0f;
    float ballYHeight = 15.0f;
    private GameObject[] balls;
    // Start is called before the first frame update
    void Start()
    {
        balls = new GameObject[ballsNum];
        for (int i = 0; i < ballsNum; i++)
        {
            balls[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            balls[i].transform.name = "ball" + i;
            balls[i].transform.position = new Vector3(Random.Range(-22.0f, 38.0f), Random.Range(1.0f, 15.0f) + ballStartHeight, 0);
            balls[i].transform.parent = this.transform;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < ballsNum; i++)
        {
            balls[i].transform.position -= speed * Time.deltaTime * Vector3.up;
            if(balls[i].transform.position.y < -1)
            {
                
                balls[i].transform.position = new Vector3(Random.Range(-22.0f, 38.0f), Random.Range(1.0f, 15.0f) + 15, 0);
                player.GetComponent<PlayerController>().IncreaseBallDodged();

            }
            if(Mathf.Abs(balls[i].transform.position.x-player.transform.position.x) < 1 && (Mathf.Abs(balls[i].transform.position.y - player.transform.position.y) < 1))
            {
                print("Game over!!!");
                
                player.GetComponent<PlayerController>().SetLost();
                gameOver.SetActive(true);
            }
            
            
        }

        
        /*if (this.transform.position.y != -35)
        {
            this.transform.Translate(new Vector3(0,-0.01f,0));
        }
        if (this.transform.position.y < -35)
        {
            this.transform.position = new Vector3(0, 0, 0);
        }*/
    }
}
