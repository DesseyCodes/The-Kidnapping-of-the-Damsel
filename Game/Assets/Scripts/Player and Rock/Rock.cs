using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField]
    public static int rocks;
    [SerializeField] int bounces;
    [SerializeField] bool canBreak;
    [Tooltip ("Time in seconds to stop after last collision.\nOnly works if the rock doesn't break.")]
    [SerializeField] float stopTime;
    [SerializeField] AudioClip treeHitSound, defaultHitSound;
    [SerializeField] float volume;

    int bouncesLeft;
    WaitForSeconds waitForStopTime;
    Rigidbody2D rb;

    void Start()
    {
        bouncesLeft = bounces;
        rb = GetComponent<Rigidbody2D>();
        waitForStopTime = new WaitForSeconds(stopTime);
        rocks = 1;
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "trees")
            AudioSource.PlayClipAtPoint(treeHitSound, transform.position, volume);
        else if(defaultHitSound != null)
            AudioSource.PlayClipAtPoint(defaultHitSound, transform.position, volume);

        Damageable damageable = other.gameObject.GetComponent<Damageable>();

        if (damageable != null)
            damageable.ChangeHP(-damage);

        this.bouncesLeft--;
        rocks--;
        
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