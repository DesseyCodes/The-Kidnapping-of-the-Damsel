using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;
    [SerializeField] bool targetPlayer;
    GameObject target;
    Vector3 moveDirection;

    void Start()
    {
        if(targetPlayer)
            target = GameObject.FindWithTag("Player");
            
        if(target != null)
            moveDirection = (target.transform.position - transform.position).normalized;
        else
            moveDirection = Vector2.down;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Damageable damageable = other.gameObject.GetComponent<Damageable>();

        if(damageable != null)
            damageable.ChangeHP(-damage);

        HeartScript heartScript = other.gameObject.GetComponent<HeartScript>();

        if(heartScript != null)
            heartScript.Damage();
 
        Destroy(gameObject);
    }
}
