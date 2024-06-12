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
    private Coroutine pulseCoroutine; // Reference to the pulsing coroutine

    // Reference to the AudioSource component
    public AudioSource timerSoundSource;
    // Reference to the AudioClip for the timer sound
    public AudioClip timerSoundClip;

    void Start()
    {
        isRunning = false;
        startbutton.SetActive(true);
        timerstartscreen.SetActive(false);
        remainingTime = countdownTime;
        UpdateTimerDisplay(remainingTime);

        // Assign the AudioClip to the AudioSource
        if (timerSoundSource != null && timerSoundClip != null)
        {
            timerSoundSource.clip = timerSoundClip;
            timerSoundSource.volume = 10f;
            timerSoundSource.loop = true; // Set the sound to loop
        }
    }

    void Update()
    {
        if (isRunning)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay(remainingTime);
            if (remainingTime <= 0f)
            {
                StartCoroutine(Gameoverdisplay());
                isRunning = false;
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
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
            pulseCoroutine = null;
            timerText.fontSize = 1; // Reset font size
        }
        if (timerSoundSource != null && timerSoundSource.isPlaying)
        {
            timerSoundSource.Stop(); // Stop the sound if it is playing
        }
    }

    private IEnumerator Gameoverdisplay()
    {
        timerText.text = "GAME OVER";
        timerText.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(3f);
        OnReset(); // Call OnReset after displaying "GAME OVER" for 3 seconds
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        if (remainingTime <= 5f && pulseCoroutine == null)
        {
            pulseCoroutine = StartCoroutine(PulseText());
            if (timerSoundSource != null && !timerSoundSource.isPlaying)
            {
                timerSoundSource.Play(); // Play the sound when the remaining time is 5 seconds or less
            }
        }
        else if (remainingTime > 5f && pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
            pulseCoroutine = null;
            timerText.fontSize = 1; // Reset font size
            if (timerSoundSource != null && timerSoundSource.isPlaying)
            {
                timerSoundSource.Stop(); // Stop the sound if the remaining time is more than 5 seconds
            }
        }

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
        }
    }

    private IEnumerator PulseText()
    {
        float time = 0f;
        float minFontSize = 1f; // Adjust as needed
        float maxFontSize = 1.3f; // Adjust as needed
        float pulseSpeed = 6f; // Adjust as needed

        while (remainingTime <= 5f)
        {
            float fontSize = Mathf.Lerp(minFontSize, maxFontSize, (Mathf.Sin(time * pulseSpeed) + 1f) / 2f);
            timerText.fontSize = fontSize;
            timerText.color = new Color(1, 0, 0); // Set color to red
            time += Time.deltaTime;
            yield return null;
        }
    }
}
