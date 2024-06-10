using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckNonRecycables : MonoBehaviour
{
    [SerializeField]
    public int Points;
    [SerializeField]
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "NotRecycable")
        {
            Debug.Log(other.gameObject.name + " is destroyed");
            Destroy(other.gameObject);
            Player.GetComponent<Score>().Points += 1;
        }

        if (other.gameObject.tag == "Recycable")
        {
            Destroy(other.gameObject);
        }

    }
}
