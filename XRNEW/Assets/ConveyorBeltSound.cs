using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltSound : MonoBehaviour
{
    [SerializeField]
    public GameObject button;
  
    [SerializeField]
    public AudioClip conveyorsoundeffect;

    private AudioSource audioSource;
    private bool isPlayingSound;

    void Start()
    {
        isPlayingSound = false;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = conveyorsoundeffect;
        audioSource.Stop();
        audioSource.volume = 2.0f;
    }


    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (button.activeSelf==false ) 
        {   
            if (isPlayingSound == false)
            {
                audioSource.Play();
                audioSource.loop = true;
                isPlayingSound = true;
            }
 
        }
        if (button.activeSelf)
        {
            if (isPlayingSound == true)
            {
                audioSource.Stop();
                isPlayingSound = false;
            }

        }
    }
}
