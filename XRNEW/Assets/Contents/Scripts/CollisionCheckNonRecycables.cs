using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckNonRecycables : MonoBehaviour
{
    [SerializeField]
    public int Points;
    [SerializeField]
    public GameObject Player;
    [SerializeField]
    public AudioClip wrongsoundeffect;

    private AudioSource wrongsound;
    [SerializeField]
    public AudioClip correctsoundeffect;

    private AudioSource correctsound;

    void Start()
    {
        wrongsound = gameObject.AddComponent<AudioSource>();
        wrongsound.playOnAwake = false;
        wrongsound.clip = wrongsoundeffect;
        wrongsound.volume = 5.0f;
        correctsound = gameObject.AddComponent<AudioSource>();
        correctsound.playOnAwake = false;
        correctsound.clip = correctsoundeffect;
        correctsound.volume = 2.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "NotRecycable")
        {
    
            Destroy(other.gameObject);
            Player.GetComponent<Score>().Points += 1;
            correctsound.Play();
        }

        if (other.gameObject.tag == "Recycable")
        {
            Destroy(other.gameObject);
            wrongsound.Play();
        }

    }
}
