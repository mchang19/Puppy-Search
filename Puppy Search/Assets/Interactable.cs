using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject clueObject; //Only drag in the object this script is attached to if it is a clue

    public Text dialogueText;
    public string dialogue;

    public bool playerInRange; //if the player is close enough to trigger interaction or not
    public bool isClue; //if the object is a "clue" to progress the story or not

    private float seconds = 2.0f;

    void Start()
    {
        dialogueBox.SetActive(false);
        clueObject.SetActive(true);
        isClue = false;
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
            Debug.Log($"OnTriggerEnter called. other's tag was {other.tag}.");
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
            Debug.Log($"OnTriggerExit called. other's tag was {other.tag}.");
        }
    }

    //Check if the object player is interacting with is a "clue" for story progression
    private void ClueCheck(GameObject _clueCheck)
    {
        if (_clueCheck.CompareTag("Clue"))
        {
            isClue = true;
            Debug.Log($"This is a clue!");
        }
        else
        {
            isClue = false;
            Debug.Log($"This is not a clue!");
        }
    }

    public IEnumerator RemoveDialogue(float seconds)
    {
        ClueCheck(clueObject);

        if (isClue)
        {
            clueObject.GetComponent<Renderer>().enabled = false;
        }

        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;

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
