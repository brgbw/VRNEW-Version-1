using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;
using System.Collections;
public class TimerStart : MonoBehaviour
{
    public GameObject startbutton;
    public TextMeshProUGUI timerText; // Reference to a TextMeshProUGUI component for displaying the timer
    public GameObject timerstartscreen; // Reference to screen
    public GameObject ReturnMenuButton;
    [SerializeField]
    public float countdownTime; // Set the initial countdown time in seconds
    public float remainingTime;
    private bool isRunning;

    void Start()
    {
        isRunning = false;
        startbutton.SetActive(true);
        timerstartscreen.SetActive(false);
        remainingTime = countdownTime;
        UpdateTimerDisplay(remainingTime);

        // Log to check if Start() runs correctly
        
    }


    void Update()
    {

        if (isRunning)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay(remainingTime);
            if (remainingTime <= 0f)
            {
                Gameoverdisplay();
            }

        }
    }

    public void StartTimer()
    {
        timerstartscreen.SetActive(true);
        isRunning = true;
        remainingTime = countdownTime; // Reset the timer
        startbutton.SetActive(false);
        ReturnMenuButton.SetActive(false);

        // Log to check if StartTimer() runs correctly
 
    }

    public void OnReset()
    {
        timerstartscreen.SetActive(false);
        startbutton.SetActive(true);
        ReturnMenuButton.SetActive(true);
        isRunning = false;
        remainingTime = countdownTime;  
        UpdateTimerDisplay(remainingTime);
        timerText.color = new Color(1, 1, 1);
        timerText.fontSize = 1;


    }
    private IEnumerator Gameoverdisplay()
    {
       
       timerText.text = "GAME OVER";
       timerText.color = new Color(1, 0, 0);
       isRunning = false;
       yield return new WaitForSeconds(3f);

    }
    private void UpdateTimerDisplay(float time)
    {
        timerText.color = new Color(1, 1, 1);
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        if (remainingTime <= 5f)
        {
            timerText.color = new Color(1, 0, 0);
            timerText.fontSize += 0.001f;
        }

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            OnReset();
        }





    }
}
