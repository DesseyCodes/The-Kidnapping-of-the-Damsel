using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Village") || SceneManager.GetActiveScene().name.Contains("Level"))
        {
            DontDestroyOnLoad(this);
            this.gameObject.SetActive(true);
        }
    }
}
