using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDog : MonoBehaviour
{

    public GameObject dog;
    public GameObject paws;

    public GameObject prereq;

    // Start is called before the first frame update
    void Start()
    {
        dog.SetActive(false);
        paws.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (prereq.GetComponent<Renderer>().enabled == true)
        {
            dog.SetActive(true);
            paws.GetComponent<Renderer>().enabled = true;
        }
    }
}
