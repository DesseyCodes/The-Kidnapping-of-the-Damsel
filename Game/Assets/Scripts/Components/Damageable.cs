using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] int hitPoints;
    [SerializeField] AudioClip[] hitSounds;
    [SerializeField] AudioClip[] defeatSounds;
    [SerializeField] float volume;
    int currentHP;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHP = hitPoints;
    }

    public void ChangeHP(int value)
    {
        currentHP += value;

        if (currentHP > hitPoints)
            currentHP = hitPoints;
            
        if(currentHP <= 0)
            Destroy(gameObject);

        if(audioSource != null)
            audioSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length-1)], volume);
    }

    void OnDestroy()
    {
        // OnDestroy is also called when unloading a scene or exiting play mode.
        // This return doesn't let the next lines run and instatiate game objects ("one shot audio" in this case) at that time.
        if(!gameObject.scene.isLoaded) return;
        AudioSource.PlayClipAtPoint(defeatSounds[Random.Range(0, defeatSounds.Length-1)], transform.position, volume);
    }
}
