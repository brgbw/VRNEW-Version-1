using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerStart : MonoBehaviour
{
    public GameObject startbutton;
    public TextMeshProUGUI timerText; // Reference to a TextMeshProUGUI component for displaying the timer
    public GameObject timerstartscreen; //Reference to screen
    [SerializeField]
    public float countdownTime; // Set the initial countdown time in seconds
    private float remainingTime;
    private bool isRunning = false;
    
    void Start()
    {
        startbutton.SetActive(true);
        timerstartscreen.SetActive(false);
        remainingTime = countdownTime;
        UpdateTimerDisplay(remainingTime);
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
            }
            UpdateTimerDisplay(remainingTime);
        }
        OnReset();
    }

    public void StartTimer()
    {
        timerstartscreen.SetActive(true);
        isRunning = true;
        remainingTime = countdownTime; // Reset the timer
        startbutton.SetActive(false);
    }

    public void OnReset()
    {
   
      timerstartscreen.SetActive(false);
      startbutton.SetActive(true);

    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000F);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}