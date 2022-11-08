using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private SpriteRenderer playerSR;

    public Transform launchOffset;

    public Sprite[] spriteDir;

    public float pSpeed = 4f;

    public GameObject rockProjectile;
    public float rockSpeed;
    private bool hasRock;

    public bool game;


    Vector2 pMovement; // We'll set this variable in the update method
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();
        hasRock = true;
        game = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axi for movement
        pMovement.x = Input.GetAxisRaw("Horizontal");
        pMovement.y = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + pMovement * pSpeed * Time.fixedDeltaTime); // The lovely Time.fixedDeltaTime prevents those of use with super fast computers from going crazy fast
        if (Input.GetMouseButtonDown(0) && hasRock == true)
        {
            Throw(); // Throw method created down below
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            playerSR.sprite = spriteDir[0];
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            playerSR.sprite = spriteDir[1];
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            playerSR.sprite = spriteDir[2];
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            playerSR.sprite = spriteDir[3];
        }

    }



    public void Throw()
    {
        // Instantiate the rockProjectile object at the player's position and the player's rotation
        GameObject rock = Instantiate(rockProjectile, launchOffset.position, launchOffset.rotation);
        Rigidbody2D rockRB = rock.GetComponent<Rigidbody2D>();
        rockRB.AddForce(new Vector2 (transform.position.x +1, transform.position.y +1) * rockSpeed, ForceMode2D.Impulse); // Apply an impulse force in the direction that would be up
        hasRock = false; // Set hasRock to false
    }
        
}
