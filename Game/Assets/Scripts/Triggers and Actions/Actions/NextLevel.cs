using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : Action
{
    [SerializeField] string levelName;
    [SerializeField] float loadDelay;
    float timer;
    
    void Start()
    {
        DisableTrigger();
        timer = loadDelay;
    }

    void Update()
    {
        if(timer < 0)
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        else
            timer -= Time.deltaTime;
    }   
}