using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QueBallController : MonoBehaviour
{
    public float speed = 5;
    public float dashBoost = 5;
    public float dashCooldown = 3;
    float prevTime;
    private Rigidbody rb;
    private float movementX, movementY;
    public int score = 0;
    public int winScore = 10;
    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI EndGameUI;
    public TextMeshProUGUI DashUI;
    public GameObject pickupSpawner;
    public GameObject Restart;


    

    // Start is called before the first frame update
    void Start()
    {   MyControls inputAction = new MyControls();
        rb = GetComponent<Rigidbody>();
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnDash(InputValue dashValue)
    {
        if (!((prevTime + dashCooldown) < Time.time)) return;
        prevTime = Time.time;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed * dashBoost * 10);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        SetDashText();

        if (score == winScore)
        {
            Time.timeScale = 0;
            EndGameUI.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            pickupSpawner.GetComponent<PickUpController>().breakPickup();

            score++;

            SetScoreText(score);
        }
    }*/

    public void RestartGame()
    {
        Time.timeScale = 1;
        score = 0;
        SceneManager.LoadScene("Billards");
    }

    public void addScore()
    {
        score++;
        SetScoreText();
    }
    public void SetScoreText()
    {
        ScoreUI.text = "Score: " + score + "/" + winScore;

    }

    private void SetDashText()
    {

        int timer = Mathf.RoundToInt((prevTime + dashCooldown) - Time.time);
        if (timer <= 0)
            DashUI.text = "Dash: Spacebar";
        else
            DashUI.text = "Dash (" + timer + "s Cooldown): Spacebar";
    }
}
