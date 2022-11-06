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
    void Start()
    {
        DisableTrigger();

        if(fadeImage == null) 
            Debug.Log(gameObject.name + ": No image set to 'fade image'.");
        else if(secondsToFade < 0)
            Debug.Log(gameObject.name + ": 'Seconds to fade' must be 0 or greater.");
        else
            StartCoroutine(NextLevelTransition());
    }

    IEnumerator NextLevelTransition()
    {
        fadeImage.enabled = true;
        Color c = fadeImage.color;
        c.a = 0.0f;
        fadeImage.color = c; // Changing the color alpha (a) directly doesn't work, so it must be stored in the 'c' variable;

        float stepToFade = 1.0f/secondsToFade;
        //Transition to fully opaque;
        while(c.a < 1.0f)
        {
            c.a += stepToFade * Time.deltaTime;
            fadeImage.color = c; 
            yield return null;
        }
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}