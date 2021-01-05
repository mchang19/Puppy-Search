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

    // Start is called before the first frame update
    void Start()
    {
        nextClue1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (prereqClue1.GetComponent<Renderer>().enabled == true && prereqClue2.GetComponent<Renderer>().enabled == true)
        {
            visCheck(nextClue1);
            visCheck(nextClue2);
            visCheck(nextClue3);
        }
    }

    //Check if the nextClue(x) object should be made visible/invisible
    private void visCheck(GameObject _visCheck)
    {
        if (_visCheck.CompareTag("MakeVisible"))
        {
            _visCheck.SetActive(true);
        }
        else
        {
            _visCheck.SetActive(false);
        }
    }
}
