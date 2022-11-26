using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioClip collideSound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = collideSound;
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
