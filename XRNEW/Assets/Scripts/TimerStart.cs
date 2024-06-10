using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;

public class TimerStart : MonoBehaviour
{
    public GameObject startbutton;
    public TextMeshProUGUI timerText; // Reference to a TextMeshProUGUI component for displaying the timer
    public GameObject timerstartscreen; // Reference to screen
    [SerializeField]
    public float countdownTime; // Set the initial countdown time in seconds
    private float remainingTime;
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
            if (remainingTime <= 0f)
            {
                remainingTime = 0f;
                timerText.text = "GAME OVER";
                timerText.color = new Color(1, 0, 0);
                isRunning = false;
                OnReset(); // Reset once the timer finishes
            }
            UpdateTimerDisplay(remainingTime);
 
         
        }
    }

    public void StartTimer()
    {
        timerstartscreen.SetActive(true);
        isRunning = true;
        remainingTime = countdownTime; // Reset the timer
        startbutton.SetActive(false);

        // Log to check if StartTimer() runs correctly
 
    }

    public void OnReset()
    {
        timerstartscreen.SetActive(false);
        startbutton.SetActive(true);
        isRunning = false;
        remainingTime = countdownTime;  
        UpdateTimerDisplay(remainingTime);

       
        
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000F);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

  
        Debug.Log($"Timer display updated: {timerText.text}");
    }
}
