using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel_action : Action
{
    [SerializeField] string levelName;
    [SerializeField] float loadDelay;
    WaitForSeconds timer;
    
    void Start()
    {
        DisableTrigger();
        timer = new WaitForSeconds(loadDelay);
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return timer;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}