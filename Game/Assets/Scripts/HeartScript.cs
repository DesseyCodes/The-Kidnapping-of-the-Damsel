using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int health;
    public Image heartsDisplay;
    public Sprite[] hearts;

    private Collider2D pCollider;
    void Start()
    {
        pCollider = GetComponent<Collider2D>();
    }

    void Damage()
    {
        health--;

        if (health == 3)
            heartsDisplay.sprite = hearts[2];

        else if (health == 2)
            heartsDisplay.sprite = hearts[1];

        else if (health == 1)
            heartsDisplay.sprite = hearts[0];

    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Rock") || collision.gameObject.tag.Equals("Bird") || collision.gameObject.tag.Equals("PlayerHurt"))
        {
            Debug.Log("We got hit!");
            Damage();
        }
    }
}
