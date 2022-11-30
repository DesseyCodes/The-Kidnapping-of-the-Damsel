using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : Action
{
    [SerializeField] float quitDelay;
    WaitForSeconds waitForDelay;
    void OnEnable()
    {
        waitForDelay = new WaitForSeconds(quitDelay);
        StartCoroutine(Quit());
    }
    IEnumerator Quit()
    {
        yield return waitForDelay;
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
