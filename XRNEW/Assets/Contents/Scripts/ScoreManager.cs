using TMPro;
using UnityEngine;
using System.Collections;

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
    private Coroutine scoreDisplayCoroutine; // Reference to the coroutine

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
            player.GetComponent<Score>().Points = 0;
            UpdateScoreDisplay();
        }
    }

    private void CheckHighScore()
    {
        if (currentScore > highScore)
        {
            player.GetComponent<Score>().HighScore = currentScore;
            highScore = currentScore;
            UpdateHighScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreDisplayCoroutine != null)
        {
            StopCoroutine(scoreDisplayCoroutine);
        }
        scoreText.text = "Current Score: " + currentScore;
        scoreText.gameObject.SetActive(true);
        scoreDisplayCoroutine = StartCoroutine(HideScoreAfterDelay(2f));
    }

    private IEnumerator HideScoreAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        scoreText.gameObject.SetActive(false);
    }

    private void UpdateHighScoreDisplay()
    {
        highScoreText.text = "Highest Score: " + highScore;
    }
}
