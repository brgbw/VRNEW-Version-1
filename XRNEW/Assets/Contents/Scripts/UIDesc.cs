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

    // Method to update the UI when an object is manipulated
    public void UpdateDescription()
    {
        NameText.text = objectName;
        DescriptionText.text = description;
        if (Recycable)
        {
            Isrecycable.text = "Recycable";
        }
        else
        {
            Isrecycable.text = "Not Recycable";
        }
    }


}