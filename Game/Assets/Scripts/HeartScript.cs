using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int health;
    int currentHealth;
    public Image heartsDisplay;
    public Sprite[] hearts;

    private Collider2D pCollider;
    void Start()
    {
        pCollider = GetComponent<Collider2D>();
        currentHealth = health;
    }

    void Damage()
    {
        currentHealth--;

        if (currentHealth == 3)
            heartsDisplay.sprite = hearts[2];

        else if (currentHealth == 2)
            heartsDisplay.sprite = hearts[1];

        else if (currentHealth == 1)
            heartsDisplay.sprite = hearts[0];

    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("We got hit!");
        if (collision.gameObject.tag.Equals("Rock") 
        || collision.gameObject.tag.Equals("Bird") 
        || collision.gameObject.tag.Equals("PlayerHurt"))
        {
            Damage();
        }
    }
}
