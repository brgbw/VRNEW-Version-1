using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;

    [SerializeField]
    public TextMeshProUGUI ScoreText;

    [SerializeField]
    public TextMeshProUGUI HighScoreText;

    public int currentscore;
    public int highscore;
    
    void Update()
    {
        currentscore = Player.GetComponent<Score>().Points;
        ScoreText.text = "Current Score: " + Player.GetComponent<Score>().Points.ToString();

        if (currentscore > highscore)
        {
            highscore = currentscore;
            HighScoreText.text = "Highest Score: "+ Player.GetComponent<Score>().Points.ToString();
        }


    }
}
