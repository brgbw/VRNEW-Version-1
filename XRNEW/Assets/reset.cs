using UnityEngine;
using System.Collections.Generic;

public class reset : MonoBehaviour
{
    // Struct to hold the initial transform data
    private struct InitialTransform
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }

    // Dictionary to map each child to its initial transform data
    private Dictionary<Transform, InitialTransform> initialTransforms = new Dictionary<Transform, InitialTransform>();

    public Transform parentTransform; // Assign the parent object in the Inspector

    void Start()
    {
        // Store the initial transforms of all children
        foreach (Transform child in parentTransform)
        {
            InitialTransform initialTransform = new InitialTransform
            {
                position = child.localPosition,
                rotation = child.localRotation,
                scale = child.localScale
            };
            initialTransforms[child] = initialTransform;
        }
    }

    // This function will be called when the button is pressed
    public void ResetChildTransforms()
    {
        if (parentTransform == null)
        {
            Debug.LogError("Parent Transform is not assigned.");
            return;
        }

        // Reset each child's transform to its initial values
        foreach (Transform child in parentTransform)
        {
            if (initialTransforms.ContainsKey(child))
            {
                InitialTransform initialTransform = initialTransforms[child];
                child.localPosition = initialTransform.position;
                child.localRotation = initialTransform.rotation;
                child.localScale = initialTransform.scale;
            }
        }
    }
}
