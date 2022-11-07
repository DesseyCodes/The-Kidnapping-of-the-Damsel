using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn_action : Action
{
    [SerializeField] Image fadeImage;
    [SerializeField] float secondsToFade;
    void Start()
    {
        DisableTrigger();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
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
    }
}
