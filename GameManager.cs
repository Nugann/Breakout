using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public BallController theBall;
    public bool gameActive;
    public Text livesText;
    public int lives;
    public GameObject gameOverScreen;
    public int currentScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallController>();
        livesText.text = "Lives Remaining: " + lives;
        scoreText.text = "Score: " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !gameActive)  
        {
            theBall.ActivateBall();
            gameActive = true;
        }
    }
    public void RespawnBall()
    {
        gameActive = false;
        lives -= 1;
        if(lives<0)
        {
            theBall.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            livesText.text = "No Lives Left";
        } else
        {
            livesText.text = "Lives Remaining: " + lives;
        }
    }
    public void AddScore(int ScoreToAdd)
    {
        currentScore += ScoreToAdd;
        scoreText.text = "Score: " + currentScore;
    }
}