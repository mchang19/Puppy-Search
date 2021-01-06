using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextClue : MonoBehaviour
{
    public GameObject prereqClue1; //Object that should have been made visible in order for next clue to appear
    public GameObject prereqClue2;
    public GameObject nextClue1; //Object to make visible/invisible to set up for next clue
    public GameObject nextClue2;
    public GameObject nextClue3;

    public GameObject enableClue; //Allow next clue object to use the Interactable script

    // Start is called before the first frame update
    void Start()
    {
        nextClue1.GetComponent<Renderer>().enabled = false;
        nextClue2.GetComponent<Renderer>().enabled = false;
        nextClue3.GetComponent<Renderer>().enabled = true;
        enableClue.GetComponent<Interactable>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (prereqClue1.GetComponent<Renderer>().enabled == true && prereqClue2.GetComponent<Renderer>().enabled == true)
        {

            visCheck(nextClue1);
            visCheck(nextClue2);
            visCheck(nextClue3);

            enableClue.GetComponent<Interactable>().enabled = true;
        }
    }

    //Check if the nextClue(x) object should be made visible/invisible
    private void visCheck(GameObject _visCheck)
    {
        if (_visCheck.CompareTag("Clue2") || _visCheck.CompareTag("Clue3"))
        {
            _visCheck.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            _visCheck.GetComponent<Renderer>().enabled = false;
        }
    }
}
