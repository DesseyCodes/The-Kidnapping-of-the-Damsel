using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int health;
    int currentHealth;
    private Image heartsDisplay;
    public Sprite[] hearts;

    private Collider2D pCollider;
    void Start()
    {
        pCollider = GetComponent<Collider2D>();
        heartsDisplay = GameObject.Find("hearts display").GetComponent<Image>();
        currentHealth = health;
    }

    public void Damage()
    {
        currentHealth--;

        if (currentHealth == 3)
            heartsDisplay.sprite = hearts[3];

        else if (currentHealth == 2)
            heartsDisplay.sprite = hearts[2];

        else if (currentHealth == 1)
            heartsDisplay.sprite = hearts[1];

        else if (currentHealth == 0)
        {
            heartsDisplay.sprite = hearts[0];
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("We got hit!");
        if (collision.gameObject.tag.Equals("Rock") || collision.gameObject.tag.Equals("Bird"))
        {
            Damage();
        }
    }
}
