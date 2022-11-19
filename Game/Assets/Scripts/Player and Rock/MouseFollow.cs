using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
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

       // Cursor.visible = false;


        transform.position = worldPos;
    }
}
