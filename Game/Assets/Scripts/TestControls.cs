using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestControls : MonoBehaviour
{   
    [SerializeField] KeyCode resetPositionKey;
    [SerializeField] Vector2 startPosition;
    [SerializeField] KeyCode reloadSceneKey;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(startPosition == Vector2.zero)
            startPosition = player.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(resetPositionKey))
            ResetPosition();
        if(Input.GetKeyDown(reloadSceneKey))
            ReloadScene();
    }

    void ResetPosition()
    {
        player.transform.position = startPosition;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}