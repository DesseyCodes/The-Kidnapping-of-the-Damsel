using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel_action : Action
{
    [SerializeField] string levelName;
    
    void Start()
    {
        DisableTrigger();
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);        
    }
}