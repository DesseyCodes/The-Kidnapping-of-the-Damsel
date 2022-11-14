using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Action
{
    [SerializeField] AudioClip audioclip;
    [SerializeField] float volume;
    [SerializeField] bool playContinuously, playOneShot, playAtPoint;
    [SerializeField] Transform point;

    void OnEnable()
    {
        DisableTrigger();

        AudioSource audioSource = GetComponent<AudioSource>();

        if(playAtPoint) 
            AudioSource.PlayClipAtPoint(audioclip, point.position, volume);

        else if(playOneShot)
            audioSource.PlayOneShot(audioclip, volume);
            
        else if(playContinuously && !audioSource.isPlaying)
            audioSource.Play();

        if (waitUntilEnd)
            StartCoroutine(WaitToSignal(audioclip.length));
        else
            SignalSequencer();
    }

    IEnumerator WaitToSignal(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SignalSequencer();
    }
    
}