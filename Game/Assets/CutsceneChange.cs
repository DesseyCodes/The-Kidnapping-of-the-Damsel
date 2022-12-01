using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChange : MonoBehaviour
{
    public int sceneIndex;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(sceneIndex);
    }
}
