using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;

    public float pSpeed = 4f;

    public GameObject rockProjectile;
    public float rockSpeed;
    private bool hasRock;



    Vector2 pMovement; // We'll set this variable in the update method
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        hasRock = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axi for movement
        pMovement.x = Input.GetAxisRaw("Horizontal");
        pMovement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") && hasRock == true)
        {
            Throw(); // Throw method created down below
        }
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + pMovement * pSpeed * Time.fixedDeltaTime); // The lovely Time.fixedDeltaTime prevents those of use with super fast computers from going crazy fast
    }

    public void Throw()
    {
        // Instantiate the rockProjectile object at the player's position and the player's rotation
        GameObject rock = Instantiate(rockProjectile, transform.position, transform.rotation);
        Rigidbody2D rockRB = rock.GetComponent<Rigidbody2D>();
        rockRB.AddForce(Vector2.up * rockSpeed, ForceMode2D.Impulse); // Apply an impulse force in the direction that would be up
        hasRock = false; // Set hasRock to false
    }
}
