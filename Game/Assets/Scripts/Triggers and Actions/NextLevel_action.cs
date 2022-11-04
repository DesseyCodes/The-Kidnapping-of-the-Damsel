using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel_action : Action
{
    [SerializeField] string levelName;
    [SerializeField] Image fadeImage;
    // + Add a time variable
    void Start()
    {
        if(fadeImage == null) 
            Debug.Log(gameObject.name + ": No image set to 'fade image'");
        else
            StartCoroutine(NextLevelTransition());
    }

    IEnumerator NextLevelTransition()
    {
        fadeImage.enabled = true;
        Color c = fadeImage.color;
        c.a = 0.0f;
        fadeImage.color = c; // Changing the color directly doesn't work, so it must be stored in the 'c' variable;
        
        //Transition to fully opaque;
        while(c.a < 1.0f)
        {
            c.a += 0.33f * Time.deltaTime;
            fadeImage.color = c; 
            yield return null;
        }
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}