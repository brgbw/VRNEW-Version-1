using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorialScript : MonoBehaviour
{
    [SerializeField]
    public Interactable tutorialbutton1;
    [SerializeField]
    public Interactable Playbutton1;
    [SerializeField]
    public GameObject tutorialdescription1;

  

    // Update is called once per frame
    public void HideTutorial()
    {
        tutorialdescription1.SetActive(false);
        tutorialbutton1.enabled = true;
        Playbutton1.enabled = true;

    }
}
