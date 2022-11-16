using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] int hitPoints;
    int currentHP;

    void Start()
    {
        currentHP = hitPoints;
    }

    public void Damage(int value)
    {
        currentHP -= value;
        if(currentHP <= 0)
            Destroy(gameObject);
    }
}
