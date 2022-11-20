using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] Vector2 minPosition, maxPosition;

    private Rigidbody2D npcRB;

    public float mSpeed;

    public Vector2 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
         randomPosition = new Vector2(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y));

        npcRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        npcRB.velocity = npcRB.velocity.normalized * mSpeed;
        npcRB.AddForce(randomPosition.normalized * mSpeed * Time.deltaTime);
    }
}
