using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialscript : MonoBehaviour
{
    [SerializeField]
    public Interactable tutorialbutton;
    [SerializeField]
    public Interactable Playbutton;
    [SerializeField]
    public GameObject tutorialdescription;

    void Start()
    {
        tutorialdescription.SetActive(false);
    }

    // Update is called once per frame
    public void ShowDescription()
    {
        tutorialdescription.SetActive(true);
        tutorialbutton.gameObject.SetActive(false);
        Playbutton.gameObject.SetActive(false);
    }
}
