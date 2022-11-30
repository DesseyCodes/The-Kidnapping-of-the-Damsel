using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private SpriteRenderer playerSR;
    private BoxCollider2D playerBC;

    private Animator animator;
    private AudioSource audioSource;

    public Transform launchOffset;

    public Sprite[] spriteDir;

    public float pSpeed = 4f;

    public GameObject rockProjectile;
    public float rockSpeed;
    private bool hasRock;

    public bool game;

   public Vector2 screenPos;
    public Vector2 worldPos;
    public Vector2 mousePos;
    public AudioClip throwSound;
    public float throwVolume;

    //public Camera cam;

    Vector2 pMovement; // We'll set this variable in the update method
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();
        playerBC = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        hasRock = true;
        game = true;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Level 1")
        {
            //game = false;
        }
        // Get the horizontal and vertical axi for movement
        pMovement.x = Input.GetAxisRaw("Horizontal");
        pMovement.y = Input.GetAxisRaw("Vertical");

        animator.SetInteger("horizontal walk", (int) pMovement.x);
        animator.SetInteger("vertical walk", (int) pMovement.y);
        float xMovement = animator.GetInteger("horizontal walk");
        float yMovement = animator.GetInteger("vertical walk");

        //+++ Added this for playing the walk sound +++
        if(pMovement.magnitude > 0.1f)
            audioSource.volume = 1;
        else
            audioSource.volume = 0;
        
        if (game == true && Input.GetMouseButtonDown(0))
        {
            Throw(); // Throw method created down below
            hasRock = false;
        }

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

     void FixedUpdate()
    {

        screenPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        playerRB.MovePosition(playerRB.position + pMovement * pSpeed * Time.fixedDeltaTime);


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
        rockRB.AddForce(new Vector2 (worldPos.x - launchOffset.position.x +1, worldPos.y - launchOffset.position.y +1) * rockSpeed, ForceMode2D.Impulse); // Apply an impulse force in the direction that would be up
        audioSource.PlayOneShot(throwSound, throwVolume);
    }
}
