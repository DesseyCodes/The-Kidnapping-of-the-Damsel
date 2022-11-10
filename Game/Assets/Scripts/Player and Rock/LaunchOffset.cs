using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOffset : MonoBehaviour
{
    public GameObject player;


    public Vector2 screenPos;
    public Vector2 worldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           screenPos = Input.mousePosition;
         worldPos = Camera.main.ScreenToWorldPoint(screenPos);


        transform.position = player.transform.position;
    }
}
