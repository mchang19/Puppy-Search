using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    //Detects if player is within the box collider range of the door
    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetBool("DoorInRange", true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("DoorInRange", false);
    }
}
