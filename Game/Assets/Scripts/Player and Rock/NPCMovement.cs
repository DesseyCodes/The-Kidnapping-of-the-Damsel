using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
   // [SerializeField] Vector2 minPosition, maxPosition;

    private Rigidbody2D npcRB;

    public float mSpeed;

    public Vector2 walkDir;

    public Transform walkdir1;

    public BoxCollider2D bCollider;

    //public Vector2 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
         //randomPosition = new Vector2(
           // Random.Range(minPosition.x, maxPosition.x),
           // Random.Range(minPosition.y, maxPosition.y));

        npcRB = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(3, 11);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        npcRB.velocity = new Vector2(walkdir1.transform.position.x, walkdir1.transform.position.y) * mSpeed * Time.deltaTime;
        npcRB.AddForce(walkdir1.transform.position * mSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environmental"))
        {
            //transform.Rotate(new Vector2(0, 180));
            Debug.Log("We hit an environmental object!");
            //npcRB.MoveRotation(npcRB.rotation * 180);
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            mSpeed *= -1;
        }
    }
}
