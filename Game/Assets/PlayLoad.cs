using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayLoad : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public void LoadPlay(int sceneIndex)
    {

        StartCoroutine(LoadAsynchronously(sceneIndex));
        loadingScreen.SetActive(true);

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
