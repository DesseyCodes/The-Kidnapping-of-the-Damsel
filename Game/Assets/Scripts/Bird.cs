using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [Tooltip ("A game object containing empty game objects as waypoints. The starting waypoint will be the first.")]
    [SerializeField] Transform waypoints;
    [SerializeField] float speed, waitTime;
    [SerializeField] bool randomPositions;
    [Tooltip ("A game object with a sprite renderer.")]
    [SerializeField] GameObject nextPosHighlight;
    [SerializeField] float shootInterval;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projSpawnPos;
    Rigidbody2D rb;
    Vector2[] positions;
    Vector2 nextPosition;
    int currentIndex, routeIncrement;
    bool reachedPos, waited, gotNextPos;
    float stopTimer, cooldown;
    GameObject posHighlight;
    public GameObject bird1;
    public GameObject bird2;
    public int birds = 2;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        reachedPos = false;
        waited = false;
        stopTimer = waitTime;
        cooldown = shootInterval;

        positions = new Vector2[waypoints.childCount];
        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = waypoints.GetChild(i).position;
        }
        transform.position = positions[0];
        nextPosition = positions[0];
        currentIndex = 0;
        
        if (nextPosHighlight != null)
        {
            posHighlight = Instantiate(nextPosHighlight, transform.position, Quaternion.identity);
            posHighlight.transform.position = nextPosition;
        }
        
    }

    void FixedUpdate()
    {
        //if (bird1 == null)
        //{
        //    birds--;
        //}
        //if (bird2 == null)
        //{
        //    birds--;
        //}

        //if (birds >= 1 && Rock.rocks == null)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        
        switch(reachedPos, waited, gotNextPos)
        {
            case (false, false, false):
                Move();
            break;

            case (true, false, false):
                Wait();
                
                if(projectile != null)
                    Shoot();
            break;

            case (true, true, false):
                ChoosePosition();
            break;

            case (true, true, true):
                Reset();
            break;
        }
    }

    private void Update()
    {
        ResetLevel();
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
        stopTimer -= Time.fixedDeltaTime;

        if(stopTimer <= 0) 
            waited = true;
    }
    void ChoosePosition()
    {
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

        if(posHighlight != null)
            posHighlight.transform.position = nextPosition;
                
        gotNextPos = true;
    }
    void Reset()
    {
        reachedPos = false;
        waited = false;
        gotNextPos = false;
        stopTimer = waitTime;
    }

    void Shoot()
    {
        if(cooldown <= 0.0f)
        {
            Instantiate(projectile, projSpawnPos.position, Quaternion.identity);
            cooldown = shootInterval;
        }
        else
            cooldown -= Time.fixedDeltaTime;
    }

    void OnDestroy()
    {
        Destroy(posHighlight);
    }

    void ResetLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
