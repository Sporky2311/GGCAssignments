using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouncyPlayerController : MonoBehaviour
{
    private bool lost = false;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI gameTextUI;
    
    int score = 0;
    float time = 0;
    bool pause = true;
    public GameObject Restart;
    public GameObject GameControl;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float hspeed = 8;
        float vspeed = 100;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * hspeed * h * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * vspeed * v * Time.deltaTime);

        time += Time.deltaTime;
        timeUI.text = "Time: " + Mathf.RoundToInt(time)+ "s";
        scoreUI.text = "Score: " + score;

    }
    public void SetLost()
    {
        lost = true;
        GameControl.SetActive(false);
        Restart.SetActive(true);
        if (lost)
        {
            setTime(0);
        }
        else
        {
            setTime(1);
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void setTime(int speed)
    {
        Time.timeScale = speed;
    }

    public void ControlGame()
    {
        if (Time.timeScale == 0)
        {
            //unpause
            Time.timeScale = 1;
            gameTextUI.text = "Pause Game";
        }
        else if (Time.timeScale == 1)
        {
            //pause
            Time.timeScale = 0;
            gameTextUI.text = "Start Game";
        }
        
    }
    public void RestartGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 1;
        Restart.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
