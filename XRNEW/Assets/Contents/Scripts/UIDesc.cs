using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDesc : MonoBehaviour
{
    [SerializeField]
    private string objectName;
    [SerializeField]
    private string description;
    [SerializeField]
    private bool Recycable;
    public TextMeshProUGUI Isrecycable;
    public TextMeshProUGUI NameText; // Reference to the UI Text component for name
    public TextMeshProUGUI DescriptionText; // Reference to the UI Text component for description

   
    public GameObject RecyclingIcon;
    public GameObject NonRecyclingIcon;


    // Method to update the UI when an object is manipulated

    public void Start()
    {
        NameText.text = "";
        DescriptionText.text = "";
        Isrecycable.text = "";
        NonRecyclingIcon.SetActive(false);
        RecyclingIcon.SetActive(false);
    }
    public void UpdateDescription()
    {
        NameText.text = objectName;
        DescriptionText.text = description;
        if (Recycable)
        {
            Isrecycable.text = "Recyclable";
            RecyclingIcon.SetActive(true);
            NonRecyclingIcon.SetActive(false);
        }
        else
        {
            Isrecycable.text = "Not Recyclable";
            NonRecyclingIcon.SetActive(true);
            RecyclingIcon.SetActive(false);
        }
    }


}