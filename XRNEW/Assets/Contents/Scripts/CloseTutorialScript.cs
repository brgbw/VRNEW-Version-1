using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorialScript : MonoBehaviour
{
    [SerializeField]
    public GameObject tutorialbutton1;
    [SerializeField]
    public GameObject Playbutton1;
    [SerializeField]
    public GameObject tutorialdescription1;

  

    // Update is called once per frame
    public void HideTutorial()
    {
        tutorialdescription1.SetActive(false);
        tutorialbutton1.SetActive(true);
        Playbutton1.SetActive(true);

    }
}
