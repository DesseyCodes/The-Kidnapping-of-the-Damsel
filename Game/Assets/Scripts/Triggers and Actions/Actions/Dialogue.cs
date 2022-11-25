using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : Action
{
    [TextArea(3, 10)]
    [SerializeField] string[] messages;
    [Tooltip ("Interval between each letter.")]
    [SerializeField] float typingInterval;
    [SerializeField] string[] responses;

    Image dialoguePanel;
    Image dialogueClose;
    TMP_Text dialogueText;

    void Awake()
    {
        dialoguePanel = GameObject.Find("dialogue panel").GetComponent<Image>();
        dialogueText = GameObject.Find("dialogue text").GetComponent<TMP_Text>();
        dialogueClose = GameObject.Find("dialogue close").GetComponent<Image>();

        dialoguePanel.gameObject.SetActive(false);
        dialogueClose.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        //dialogueClose.gameObject.SetActive(true);
        dialogueText.text = "";
        dialogueText.gameObject.SetActive(true);
        dialoguePanel.gameObject.SetActive(true);
        
        StartCoroutine(ContinueDialogue());
    }

    IEnumerator ContinueDialogue()
    {
        // Show first message.
        for(int i = 0; i < messages[0].Length; i++)
        {
            dialogueText.text += messages[0][i];
            yield return new WaitForSeconds(typingInterval);
        }

        // Show all other messages.
        int messageIndex = 1;

        while(messageIndex < messages.Length)
        {
            yield return null;

            if(Input.GetButtonDown("Interact"))
            {   
                dialogueText.text = "";

                string currentMessage = messages[messageIndex];

                for(int i = 0; i < currentMessage.Length; i++)
                {
                    dialogueText.text += currentMessage[i];
                    yield return new WaitForSeconds(typingInterval);
                }
            
                messageIndex++;
            }
        }

        // Require input to end dialogue.
        bool canEnd = false;

        while(!canEnd)
        {
            yield return null;

            if(Input.GetButtonDown("Interact"))
            {
                //dialogueClose.gameObject.SetActive(false);
                dialoguePanel.gameObject.SetActive(false);
                dialogueText.text = "";
                dialogueText.gameObject.SetActive(false);
                canEnd = true;
            }
        }
        SignalToContinue();
    }
}
