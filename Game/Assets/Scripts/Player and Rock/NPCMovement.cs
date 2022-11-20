using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    private Rigidbody2D npcRB;
    public float speed;

    public Transform limit1;
    // Start is called before the first frame update
    void Start()
    {
        npcRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed);
    }
}
