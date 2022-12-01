using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

// ADD: Allow for the name of each participant to be shown during the dialogue.
public class Dialogue : Action
{
    [TextArea(3, 10)]
    [SerializeField] string[] messages;
    [Tooltip ("Interval between each letter.")]
    [SerializeField] float typingInterval;
    [SerializeField] string[] responses;
    string[] names, dialogue;
    Image dialoguePanel;
    Image dialogueClose;
    TMP_Text dialogueText;
    TMP_Text nameText;
    PlayableDirector timeline;

    void Awake()
    {
        dialoguePanel = GameObject.Find("dialogue panel").GetComponent<Image>();
        dialogueText = GameObject.Find("dialogue text").GetComponent<TMP_Text>();
        dialogueClose = GameObject.Find("dialogue close").GetComponent<Image>();

        dialoguePanel.gameObject.SetActive(false);
        dialogueClose.gameObject.SetActive(false);

        timeline = Object.FindObjectOfType<PlayableDirector>();
    }
    void OnEnable()
    {
        //dialogueClose.gameObject.SetActive(true);
        dialogueText.text = "";
        dialogueText.gameObject.SetActive(true);
        dialoguePanel.gameObject.SetActive(true);

        if(timeline != null)
            timeline.playableGraph.GetRootPlayable(0).SetSpeed(0);

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

        if(timeline != null)
            timeline.playableGraph.GetRootPlayable(0).SetSpeed(1);

        SignalToContinue();
    }
}
