using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : Action
{
    // Contains messages.
    // Types each message.
    // Waits for player input at the end of each message.
    
    [TextArea(3, 10)]
    [SerializeField] string[] messages;
    [Tooltip ("Interval between each letter.")]
    [SerializeField] float typingInterval;
    [SerializeField] string continueButton;

    Image dialoguePanel;
    TMP_Text dialogueText;

    void Awake()
    {
        dialoguePanel = GameObject.Find("dialogue panel").GetComponent<Image>();
        dialogueText = GameObject.Find("dialogue text").GetComponent<TMP_Text>();
    }
    void OnEnable()
    {
        // Calling a dialogue panel's SetActive(true) causes a hiccup. So I'm changing the alpha instead.
        SetPanelAlpha(0.42f);
        dialogueText.text = "";

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

        // Require input to end dialogue.
        bool canEnd = false;

        while(!canEnd)
        {
            yield return null;

            if(Input.GetButtonDown(continueButton))
            {
                SetPanelAlpha(0);
                dialogueText.text = "";

                canEnd = true;
            }
        }
        SignalSequencer();
    }
    void SetPanelAlpha(float alpha)
    {
        Color c = dialoguePanel.color;
        c.a = alpha;
        dialoguePanel.color = c;
    }
}
