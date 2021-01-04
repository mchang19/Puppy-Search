using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject clueObject; //Only drag in the object this script is attached to if it is a clue
    public GameObject emptytofullObject; //Drag in object that needs to be "filled" by the fullObject (eg. empty dog bowl)
    public GameObject fullObject; //Drag in object that will "fill" the empty asset (eg. dog food plane for an empty dog bowl)

    public TMP_Text dialogueText;
    public string dialogue; //Dialogue displayed for first interaction
    public string dialogue_filled; //Alternative dialogue displayed if an object is tagged "EmptytoFull" and player has already interacted with it

    public bool playerInRange; //if the player is close enough to trigger interaction or not
    public bool isClue; //if the object is a "clue" to progress the story or not
    public bool EmptyToFull; //if the object is a container that needs to be visibly "filled"
    public bool alreadyFull; //checks if the object has already been "filled", stops duplicate dialogue

    private float seconds = 2.0f;

    void Start()
    {
        dialogueBox.SetActive(false);
        clueObject.SetActive(true);
        isClue = false;
        alreadyFull = false;

        fullObject.GetComponent<Renderer>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
          StartCoroutine(RemoveDialogue(seconds));
        }
    }

    //Check if player is within range of interaction
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    //Check if player is out of range of interaction
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
            dialogueText.text = "";
        }
    }

    //Check if the object player is interacting with is a "clue" for story progression
    private void ClueCheck(GameObject _clueCheck)
    {
        if (_clueCheck.CompareTag("Clue"))
        {
            isClue = true;
        }
        else
        {
            isClue = false;
        }
    }

    //Check if the object player is interacting with is an object that needs to be "filled" (eg. empty feed tray, dog bowl)
    private void FillCheck(GameObject _fillCheck)
    {
        if (_fillCheck.CompareTag("EmptyToFull"))
        {
            EmptyToFull = true;
        }
        else
        {
            EmptyToFull = false;
        }
    }

    public IEnumerator RemoveDialogue(float seconds)
    {
        ClueCheck(clueObject);

        //Have the player "pick up" the clue, otherwise check if the object is a container needing to be filled
        if (isClue)
        {
            clueObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            FillCheck(emptytofullObject);
        }

        //If object is an empty container, make the filling visible
        if (EmptyToFull)
        {
            fullObject.GetComponent<Renderer>().enabled = true;
        }

        //Triggers dialogue box
        dialogueBox.SetActive(true);

        //Checks if the object has been interacted with already to see which line of dialogue should be displayed
        if (alreadyFull && !isClue)
        {
            dialogueText.text = dialogue_filled;
        }
        else
        {
            dialogueText.text = dialogue;
            alreadyFull = true;
        }

        yield return new WaitForSeconds(seconds);
        Debug.Log($"IEnumerator is working");

        dialogueBox.SetActive(false);
        dialogueText.text = "";

        if (isClue)
        {
            clueObject.SetActive(false);
        }
    }
}
