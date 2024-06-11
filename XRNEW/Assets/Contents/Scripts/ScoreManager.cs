using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private GameObject playButton;

    private int currentScore;
    private int highScore;
    private bool playerIsInGame;

    private void Start()
    {
        playerIsInGame = false;
        currentScore = 0;
        highScore = 0;
        UpdateScoreDisplay();
        UpdateHighScoreDisplay();
    }

    private void Update()
    {
        CheckPlayButtonState();
        UpdateCurrentScore();
        CheckHighScore();
    }

    private void CheckPlayButtonState()
    {
        playerIsInGame = !playButton.activeSelf;

        if (!playerIsInGame)
        {
            currentScore = 0;

            UpdateScoreDisplay(); // Update the display even when the game is not active
        }
    }

    private void UpdateCurrentScore()
    {
        if (playerIsInGame)
        {
            currentScore = player.GetComponent<Score>().Points;
            UpdateScoreDisplay();
        }
        if (!playerIsInGame)
        {
            currentScore = 0;
            UpdateScoreDisplay();
        }

    }

    private void CheckHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            UpdateHighScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Current Score: " + currentScore;
    }

    private void UpdateHighScoreDisplay()
    {
        highScoreText.text = "Highest Score: " + highScore;
    }

}
