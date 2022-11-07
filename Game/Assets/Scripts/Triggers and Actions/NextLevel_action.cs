using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel_action : Action
{
    [SerializeField] string levelName;
    [SerializeField] Image fadeImage;
    [SerializeField] float secondsToFade;
    [SerializeField] float delayAfterFading;
    void Start()
    {
        DisableTrigger();

        if(CheckInput())
            StartCoroutine(NextLevelTransition());
    }

    IEnumerator NextLevelTransition()
    {
        fadeImage.enabled = true;
        Color c = fadeImage.color; // The color alpha (a) can't be changed directly, so the color must be stored in the 'c' variable.
        c.a = 0.0f;
        fadeImage.color = c; 
        float stepToFade = 1.0f/secondsToFade; //Converting seconds to steps towards 100% opaque.

        //Transition from transparent to fully opaque;
        while(c.a < 1.0f)
        {
            c.a += stepToFade * Time.deltaTime;
            fadeImage.color = c; 
            yield return null;
        }
        yield return new WaitForSeconds(delayAfterFading);

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
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
        if(delayAfterFading < 0)
        {
            Debug.Log(gameObject.name + ": 'Delay after fading' must be 0 or greater.");
            check = false;
        }

        return check;
    }
}