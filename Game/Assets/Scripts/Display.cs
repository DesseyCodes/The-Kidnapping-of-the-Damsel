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
        if (SceneManager.GetActiveScene().name.Equals("MainMeu"))
        {
            Destroy(this);
            this.gameObject.SetActive(false);
        }

        else
        {
            DontDestroyOnLoad(this);
            this.gameObject.SetActive(true);
        }
    }
}
