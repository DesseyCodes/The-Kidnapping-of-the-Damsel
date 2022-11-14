using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : Action
{
    [SerializeField] Image fadeImage;
    [SerializeField] bool fadeImageIn, fadeImageOut;
    [SerializeField] float secondsToFade;

    void OnEnable()
    {
        DisableTrigger();
        
        if(CheckInput())
            StartCoroutine(Fade());

        if(!waitUntilEnd)
            SignalSequencer();
    }

    IEnumerator Fade()
    {
        fadeImage.enabled = true;
        Color c = fadeImage.color; // color.a can't be changed directly, so it must be stored in a temporary variable.
        if (fadeImageIn) c.a = 0.0f;
        else if(fadeImageOut) c.a = 1.0f;
        fadeImage.color = c;

        float stepToFade = 1.0f/secondsToFade; // Converting seconds to steps towards 100% opaque or transparent.

        // From transparent to opaque;
        if(fadeImageIn)
        {
            while(c.a <= 1.0f)
            {
                c.a += stepToFade * Time.deltaTime;
                fadeImage.color = c;
                yield return null;
            }
        }
        // From opaque to transparent;
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
            SignalSequencer();
    }
    
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
