using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Tooltip ("A game object containing empty game objects as waypoints. The starting waypoint will be the first.")]
    [SerializeField] Transform waypoints;
    [SerializeField] float speed, waitTime;
    [SerializeField] bool randomPositions;
    [Tooltip ("A game object with a sprite renderer.")]
    [SerializeField] GameObject nextPosHighlight;
    [SerializeField] AudioClip defeatSound;
    [SerializeField] float volume;
    Rigidbody2D rb;
    Vector2[] positions;
    Vector2 nextPosition;
    int currentIndex;
    int routeIncrement;
    bool reachedPos, waited, gotNextPos;
    float timer;
    GameObject posHighlight;
    
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
        transform.position = positions[0];
        nextPosition = positions[0];
        currentIndex = 0;
        
        posHighlight = Instantiate(nextPosHighlight, transform.position, Quaternion.identity);
        posHighlight.transform.position = nextPosition;
    }

    void FixedUpdate()
    {
        switch(reachedPos, waited, gotNextPos)
        {
            case (false, false, false):
                Move();
            break;

            case (true, false, false):
                Wait();
            break;

            case (true, true, false):
                ChoosePosition();
            break;

            case (true, true, true):
                Reset();
            break;
        }
    }

    void Move()
    {
        Vector2 movement = Vector2.MoveTowards(rb.position, nextPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(movement);

        if(rb.position == nextPosition)
            reachedPos = true;
    }
    void Wait()
    {
        timer -= Time.fixedDeltaTime;

        if(timer <= 0) 
            waited = true;
    }
    void ChoosePosition()
    {
        // Fix: sometimes the bird moves back and forth for a while when selecting random waypoints. 
        // Including more waypoints decreases the chance of selecting a previous one. Doesn't seem too noticeable with 6 waypoints.
        // Storing the previous position could avoid it.
        Vector2 currentPosition = nextPosition;
        while(currentPosition == nextPosition)
        {
            if(randomPositions)
                currentIndex = Random.Range(0, positions.Length);

            else
            {
                if(currentIndex == positions.Length-1)
                    routeIncrement = -1;

                else if(currentIndex == 0)
                    routeIncrement = 1;
                
                currentIndex += routeIncrement;
            }
           
            nextPosition = positions[currentIndex];
        }
        posHighlight.transform.position = nextPosition;
                
        gotNextPos = true;
    }
    void Reset()
    {
        reachedPos = false;
        waited = false;
        gotNextPos = false;
        timer = waitTime;
        // previousPosition = currentPosition;
    }

    void OnDestroy()
    {
        Destroy(posHighlight);

        // OnDestroy is also called when unloading a scene or exiting play mode.
        // This return doesn't let the next lines run and instatiate game objects ("one shot audio" in this case) at that time.
        if(!gameObject.scene.isLoaded) return;

        AudioSource.PlayClipAtPoint(defeatSound, transform.position, volume);
    }
}
