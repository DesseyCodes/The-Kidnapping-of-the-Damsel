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

    public void ChangeHP(int value)
    {
        currentHP += value;

        if (currentHP > hitPoints)
            currentHP = hitPoints;
            
        if(currentHP <= 0)
            Destroy(gameObject);
    }
}
