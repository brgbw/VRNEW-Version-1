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
        Debug.Log("Start() method executed. Initial time set.");
    }

    void Update()
    {
        if (isRunning)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0f)
            {
                remainingTime = 0f;
                isRunning = false;
                OnReset(); // Reset once the timer finishes
            }
            UpdateTimerDisplay(remainingTime);

            // Log to check timer updates
            Debug.Log($"Timer updating: {remainingTime} seconds remaining.");
        }
    }

    public void StartTimer()
    {
        timerstartscreen.SetActive(true);
        isRunning = true;
        remainingTime = countdownTime; // Reset the timer
        startbutton.SetActive(false);

        // Log to check if StartTimer() runs correctly
        Debug.Log("StartTimer() method executed. Timer started.");
    }

    public void OnReset()
    {
        timerstartscreen.SetActive(false);
        startbutton.SetActive(true);
        isRunning = false;
        // Log to check if OnReset() runs correctly
        Debug.Log("OnReset() method executed. Timer reset.");
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000F);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        // Log to check if the timer display updates
        Debug.Log($"Timer display updated: {timerText.text}");
    }
}
