using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoffeeTap : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;
    public int score;
    public int attemptsLeft;
    public int actual;
    public bool buttonPressed = false;
    public int guess;

    void Start()
    {
        score = 0;
        attemptsLeft = 8;
        UpdateScoreText();
        NewRound();
    }

    void Update()
    {
        if (attemptsLeft <= 0)
        {
            EndGame();
        }

        buttonPressed = Input.GetButton("Button");

        if (buttonPressed)
        {
            // Check if the button is held down
            if (Input.GetButton("Button"))
            {
                guess++;
            }
        }
        else if ((guess > 0) && !buttonPressed)
        {
            // Once the button is released, handle the scoring logic
            CalculateScore(guess);

            if (attemptsLeft > 0)
            {
                attemptsLeft--;
                NewRound();
            }
        }
    }

    void CalculateScore(int guess)
    {
        int difference = Mathf.Abs(guess - actual);
        if (guess == actual)
        {
            score += 100;
            score *= 5;
        }
        else if (difference <= actual * 0.25f)
        {
            score += 75;
            score *= 2;
        }
        else if (difference <= actual * 0.5f)
        {
            score += 50;
        }
        else if (difference <= actual * 0.75f)
        {
            score += 25;
        }
        // No points awarded if none of the conditions are met
        UpdateScoreText();
    }

    void NewRound()
    {
        guess = 0;
        actual = Random.Range(1000, 10000);
    }

    void EndGame()
    {
        scoreText.text = "Game Over. Final Score: " + score.ToString();
        Application.Quit();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
