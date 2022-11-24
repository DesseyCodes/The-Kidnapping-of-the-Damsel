using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int health;
    public int heartNum;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Collider2D pCollider;
    void Start()
    {
        pCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Damage();

        if (health > heartNum)
        {
            health = heartNum;
        }
    }

    void Damage()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < heartNum)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerHurt"))
        {
            Debug.Log("We hit!");
            Damage();
        }
    }
}
