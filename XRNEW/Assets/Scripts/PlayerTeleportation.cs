using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    public Camera PlayerCamera;
    public Transform GamePosition;  // Use Transform instead of Camera to just get the position and rotation
    public Interactable button;  // Use Interactable for MRTK button

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
    }

    void OnButtonClick()
    {
        // Ensure both PlayerCamera and GamePosition are assigned
        if (PlayerCamera != null && GamePosition != null)
        {
            PlayerCamera.transform.position = GamePosition.position;
            PlayerCamera.transform.rotation = GamePosition.rotation;
        }
        else
        {
            Debug.LogError("PlayerCamera or GamePosition is not assigned.");
        }
    }
}
