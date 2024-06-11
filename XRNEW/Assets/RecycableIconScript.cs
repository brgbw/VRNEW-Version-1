using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecycableIconScript : MonoBehaviour
{
    [SerializeField]
    public GameObject RecyclingIcon;
    public GameObject NonRecyclingIcon;
    public TextMeshProUGUI recyclabletextdescription;
    // Start is called before the first frame update
    void Start()
    {
        RecyclingIcon.SetActive(false);
        NonRecyclingIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (recyclabletextdescription.text == "Not Recyclable")
        {
            Debug.Log("NotR");
            NonRecyclingIcon.SetActive(true);
            RecyclingIcon.SetActive(false);
        }

        if (recyclabletextdescription.text == "Recyclable")
        {
            RecyclingIcon.SetActive(true);
            NonRecyclingIcon.SetActive(false);
        }
    }
}
