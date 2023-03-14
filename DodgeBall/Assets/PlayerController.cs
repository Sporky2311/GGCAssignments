using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool lost = false;
    public TextMeshProUGUI survivalTimeUI;
    public TextMeshProUGUI ballDodgedUI;
    private bool isDead = false;
    public float speed = 5.0f;
    Vector3 step = new Vector3(1, 0, 0);
    float timeSurvival = 0;
    int ballDodged = 0;
    //new Stuff
    public GameObject Restart;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {

            transform.position += step * speed * Time.deltaTime;
        }
        else if (Input.GetKey("right"))
        {
            transform.position -= step * speed * Time.deltaTime;
        }
        timeSurvival += Time.deltaTime;
        survivalTimeUI.text = "Survival Time: " + Mathf.RoundToInt(timeSurvival) + "s";

        ballDodgedUI.text = "Balls dodged: " + ballDodged;
       
    }

    public void IncreaseBallDodged()
    {
        ballDodged++;
    }

    public void SetLost()
    {
        lost = true;
        Restart.SetActive(true);
    }

    public void setTime(int speed)
    {
        Time.timeScale = speed;
    }


    public void RestartGame()
    {   
        lost = false;
        Restart.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
}
