using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add: Highlight the next location the bird will go.
public class Bird : MonoBehaviour
{
    [Tooltip ("A game object containing empty game objects as waypoints. The starting waypoint will be the first")]
    [SerializeField] Transform waypoints;
    [SerializeField] float speed, waitTime;
    [Tooltip ("A game object with a sprite renderer.")]
    [SerializeField] GameObject nextPosHighlight;
    Rigidbody2D rb;
    Vector2[] positions;
    Vector2 nextPosition;
    bool reachedPos, waited, gotNextPos;
    float timer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        reachedPos = false;
        waited = false;
        timer = waitTime;

        positions = new Vector2[waypoints.childCount];
        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = waypoints.GetChild(i).position;
        }
        nextPosition = positions[0];
        nextPosHighlight.transform.position = nextPosition;
    }

    void FixedUpdate()
    {
        switch(reachedPos, waited, gotNextPos)
        {
            case(true, true, true):

                reachedPos = false;
                waited = false;
                gotNextPos = false;
                timer = waitTime;
                //previousPosition = currentPosition;
                break;

            case (true, true, false):
                // Fix: sometimes the bird moves back and forth for a while.
                // Including more waypoints decreases the chance of selecting a previous one.
                // Storing the previous position could avoid it.
                Vector2 currentPosition = nextPosition;
                while(currentPosition == nextPosition)
                {
                    int randomIndex = Random.Range(0, positions.Length);
                    nextPosition = positions[randomIndex];
                }
                nextPosHighlight.transform.position = nextPosition;
                gotNextPos = true;
                
                break;

            case (true, false, false):
                timer -= Time.fixedDeltaTime;

                if(timer <= 0) 
                    waited = true;
                break;

            case (false, false, false):
                Vector2 movement = Vector2.MoveTowards(rb.position, nextPosition, speed * Time.fixedDeltaTime);
                rb.MovePosition(movement);

                if(rb.position == nextPosition)
                    reachedPos = true;
                break;
        }
    }
}
