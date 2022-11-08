using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage_action : Action
{
    [SerializeField] Image fadeImage;
    [SerializeField] bool fadeImageIn, fadeImageOut;
    [SerializeField] float secondsToFade;
    void Start()
    {
        DisableTrigger();
        
        /*
        if(fadeImageIn)
            StartCoroutine(FadeImageIn());
        else if(fadeImageOut)
            StartCoroutine(FadeImageOut());
        */
        if(CheckInput())
            StartCoroutine(FadeImage());

        if(!waitUntilEnd)
            SignalActionSequencer();
    }

    // + Trying to use a single coroutine for fading in or out.
    IEnumerator FadeImage()
    {
        fadeImage.enabled = true;
        Color c = fadeImage.color; // The color alpha (a) can't be changed directly, so the color must be stored in the 'c' variable.
        if (fadeImageIn) c.a = 0.0f;
        else if(fadeImageOut) c.a = 1.0f;
        fadeImage.color = c;

        float stepToFade = 1.0f/secondsToFade; //Converting seconds to steps towards 100% opaque or transparent.

        //Transition from transparent to fully opaque;
        if(fadeImageIn)
        {
            while(c.a <= 1.0f)
            {
                c.a += stepToFade * Time.deltaTime;
                fadeImage.color = c;
                yield return null;
            }
        }
            
        else if(fadeImageOut)
        {
            while(c.a >= 0)
            {
                c.a -= stepToFade * Time.deltaTime;
                fadeImage.color = c;
                yield return null;
            }
            fadeImage.enabled = false;            
        }

        if(waitUntilEnd)
            SignalActionSequencer();
    }

    IEnumerator FadeImageIn()
    {
        fadeImage.enabled = true;
        Color c = fadeImage.color; 
        c.a = 0.0f;
        fadeImage.color = c;

        float stepToFade = 1.0f/secondsToFade; 

        while(c.a <= 1.0f)
        {
            c.a += stepToFade * Time.deltaTime;
            fadeImage.color = c;
            yield return null;
        }

        if(waitUntilEnd)
            SignalActionSequencer();
    }
    IEnumerator FadeImageOut()
    {
        fadeImage.enabled = true;
        Color c = fadeImage.color;
        c.a = 1.0f;
        fadeImage.color = c;

        float stepToFade = 1.0f/secondsToFade;

        while(c.a >= 0)
        {
            c.a -= stepToFade * Time.deltaTime;
            fadeImage.color = c;
            yield return null;
        }
        fadeImage.enabled = false;

        if(waitUntilEnd)
            SignalActionSequencer();
    }

    //This is just to log better error messages.
    bool CheckInput()
    {
        bool check = true;
        
        if(fadeImage == null)
        {
            Debug.Log(gameObject.name + ": No image set to 'fade image'.");
            check = false;
        } 
        if(secondsToFade < 0)
        {
            Debug.Log(gameObject.name + ": 'Seconds to fade' must be 0 or greater.");
            check = false;
        }

        return check;
    }
}
