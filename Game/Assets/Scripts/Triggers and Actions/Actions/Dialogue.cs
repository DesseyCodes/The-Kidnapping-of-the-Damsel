using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : Action
{
    //Contains messages.
    //Types each message.
    //Waits for player input at the end of each message.

    [SerializeField] Image dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] string[] messages;
    [Tooltip ("Interval between each letter.")]
    [SerializeField] float typingInterval;
    [SerializeField] string continueButton;

    void OnEnable()
    {
        //Calling SetActive(true) in the dialogue panel causes a small hiccup. So I'm changing the alpha instead;
        Color c = dialoguePanel.color;
        c.a = 0.42f;
        dialoguePanel.color = c;
        dialogueText.text = "";

        StartCoroutine(ContinueDialogue());
    }

    IEnumerator ContinueDialogue()
    {
        //Show first message.
        for(int i = 0; i < messages[0].Length; i++)
        {
            dialogueText.text += messages[0][i];
            yield return new WaitForSeconds(typingInterval);
        }

        //Show all other messages.
        int messageIndex = 1;

        while(messageIndex < messages.Length)
        {
            yield return null;

            if(Input.GetButtonDown(continueButton))
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

        //Require input to end dialogue.
        bool canEnd = false;

        while(!canEnd)
        {
            yield return null;

            if(Input.GetButtonDown(continueButton))
            {
                Color c = dialoguePanel.color;
                c.a = 0;
                dialoguePanel.color = c;

                dialogueText.text = "";

                canEnd = true;
            }
        }
    }
}
