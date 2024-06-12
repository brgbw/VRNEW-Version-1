using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialscript : MonoBehaviour
{
    [SerializeField]
    public Interactable tutorialbutton;
    [SerializeField]
    public AudioClip soundeffect;
    [SerializeField]
    public Interactable Playbutton;
    [SerializeField]
    public GameObject tutorialdescription;

    private AudioSource audioSource;

    void Start()
    {
        tutorialdescription.SetActive(false);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundeffect;
        audioSource.loop = true;
        audioSource.Play();
        
    }

    // Update is called once per frame
    public void ShowDescription()
    {
        tutorialdescription.SetActive(true);
        tutorialbutton.gameObject.SetActive(false);
        Playbutton.gameObject.SetActive(false);
    }
}
