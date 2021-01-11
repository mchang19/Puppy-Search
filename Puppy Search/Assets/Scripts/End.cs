using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{

    public GameObject dog;
    public GameObject player;
    public AudioSource audioSource;

    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (dog.activeSelf && other.CompareTag("Player"))
        {
            audioSource.Play();
            dialogueBox.SetActive(true);
        }
    }
}
