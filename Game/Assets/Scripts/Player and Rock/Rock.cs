using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int damage;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Damageable damageable = other.gameObject.GetComponent<Damageable>();

        if (damageable != null)
            damageable.ChangeHP(damage);
    }   
}
