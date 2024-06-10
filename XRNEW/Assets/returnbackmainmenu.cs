using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnbackmainmenu : MonoBehaviour
{
    [SerializeField]
    public GameObject room1;
    [SerializeField]
    public GameObject room2;
    public Interactable returnbutton;  
    void OnButtonClick()
    {
  
        room1.SetActive(true);
        room2.SetActive(false);
    }
}
