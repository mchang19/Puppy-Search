using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    private Animator dogAnimator;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        dogAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dogAnimator.SetBool("PlayerInRange", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dogAnimator.SetBool("PlayerInRange", false);
        }
    }
}
