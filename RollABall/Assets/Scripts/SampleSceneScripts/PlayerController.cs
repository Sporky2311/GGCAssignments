using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
    private float movementX, movementY;
    public int score = 0;
    public int winScore = 10;
    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI EndGameUI;
    public GameObject Restart;


    MyControls inputAction = new MyControls();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (score == winScore)
        {
            Time.timeScale = 0;
            EndGameUI.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            score++;

            SetScoreText();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        score = 0;
        SceneManager.LoadScene(0);
    }
    public void SetScoreText()
    {
        ScoreUI.text = "Score: " + score + "/" + winScore;

    }
}
