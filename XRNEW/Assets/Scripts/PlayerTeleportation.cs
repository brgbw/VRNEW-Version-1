using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    public Camera PlayerCamera;
    public Transform GamePosition;  // Use Transform instead of Camera to just get the position and rotation
    public Interactable button;  // Use Interactable for MRTK button
    [SerializeField]
    public GameObject room1;
    [SerializeField]
    public GameObject room2;

    void Start()
    {
        // Ensure the button is assigned and add the listener for the click event
        if (button != null)
        {
            button.OnClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button is not assigned.");
        }
        room1.SetActive(true);
        room2.SetActive(false);

    }

    void OnButtonClick()
    {
        // Ensure both PlayerCamera and GamePosition are assigned
        room1.SetActive(false);
        room2.SetActive(true);
    }
}
