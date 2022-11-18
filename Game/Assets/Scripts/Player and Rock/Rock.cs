using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int bounces;
    [SerializeField] bool canBreak;
    [Tooltip ("Time in seconds to stop after last collision.\nOnly works if the rock doesn't break.")]
    [SerializeField] float stopTime;
    int bouncesLeft;
    WaitForSeconds waitForStopTime;
    Rigidbody2D rb;


    void Start()
    {
        bouncesLeft = bounces;
        rb = GetComponent<Rigidbody2D>();
        waitForStopTime = new WaitForSeconds(stopTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Damageable damageable = other.gameObject.GetComponent<Damageable>();

        if (damageable != null)
            damageable.ChangeHP(damage);

            this.bouncesLeft--;
        
            if(bouncesLeft < 0)
            {
                if(canBreak)
                    Destroy(gameObject);
                else
                    StartCoroutine(StopMoving());
            }
    }   

    IEnumerator StopMoving()
    {
        yield return waitForStopTime;
        rb.simulated = false;
    }
}
