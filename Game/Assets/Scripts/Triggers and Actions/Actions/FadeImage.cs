using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Fades an UI image or a sprite renderer in or out. UI image has priority over sprite renderer.
// The image component can be disabled from the hierarchy so it doesn't always stay on screen.

public class FadeImage : Action
{
    [Tooltip ("UI image.")]
    [SerializeField] Image image;
    [Tooltip ("Sprite renderer component from any game object.")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [Tooltip ("Select one")]
    [SerializeField] bool fadeImageIn, fadeImageOut;
    [SerializeField] float secondsToFade;

    void OnEnable()
    {
        if(CheckInput())
            if(image != null)
                StartCoroutine(Fade(image));
            else
                StartCoroutine(Fade(spriteRenderer));

        if(!waitUntilEnd)
            SignalToContinue();
    }

    IEnumerator Fade(Image image)
    {
        image.enabled = true;
        Color c = image.color; // color.a (alpha) can't be changed directly, so it must be stored in a temporary variable, modified and assigned back.

        float stepToFade = 1.0f/secondsToFade; // Did this so whoever uses the inspector can adjust the fading by time.

        // From transparent to opaque;
        if(fadeImageIn)
        {
            c.a = 0.0f;

            while(c.a <= 1.0f)
            {
                c.a += stepToFade * Time.deltaTime;
                image.color = c;
                yield return null;
            }
        }
        // From opaque to transparent;
        else if(fadeImageOut)
        {
            c.a = 1.0f;

            while(c.a >= 0)
            {
                c.a -= stepToFade * Time.deltaTime;
                image.color = c;
                yield return null;
            }
            image.enabled = false;            
        }

        if(waitUntilEnd) 
            SignalToContinue();
    }

    IEnumerator Fade(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.enabled = true;
        Color c = spriteRenderer.color; // color.a (alpha) can't be changed directly, so it must be stored in a temporary variable, modified and assigned back.

        float stepToFade = 1.0f/secondsToFade; // Did this so whoever uses the inspector can adjust the fading by time.

        // From transparent to opaque;
        if(fadeImageIn)
        {
            c.a = 0.0f;

            while(c.a <= 1.0f)
            {
                c.a += stepToFade * Time.deltaTime;
                spriteRenderer.color = c;
                yield return null;
            }
        }
        // From opaque to transparent;
        else if(fadeImageOut)
        {
            c.a = 1.0f;

            while(c.a >= 0)
            {
                c.a -= stepToFade * Time.deltaTime;
                spriteRenderer.color = c;
                yield return null;
            }
            spriteRenderer.enabled = false;            
        }

        if(waitUntilEnd) 
            SignalToContinue();
    }

    bool CheckInput()
    {
        bool check = true;

        // Unity would just point to a null reference in this script. Now it informs which game object lacks an image.
        if(image == null && spriteRenderer == null)
        {
            Debug.Log(gameObject.name + ": No image or sprite renderer set.");
            check = false;
        }
        
        // If secondsToFade is negative the loops would just keep running without any errors. 
        if(secondsToFade < 0)
        {
            Debug.Log(gameObject.name + ": 'Seconds to fade' must be 0 or greater.");
            check = false;
        }
        
        // If none are selected, nothing would happen and no errors would show up.
        if(fadeImageIn == false && fadeImageOut == false)
        {
            Debug.Log(gameObject.name + ": No fading set.");
            check = false;
        }

        return check;
    }
}
