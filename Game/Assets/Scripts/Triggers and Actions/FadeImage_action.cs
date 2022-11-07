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

        if(fadeImageIn)
            StartCoroutine(FadeImageIn());
        else if(fadeImageOut)
            StartCoroutine(FadeImageOut());
    }

    // + Refactor to use a single coroutine for fading in or out.
    IEnumerator FadeImage()
    {
        yield return null;
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
    }
}
