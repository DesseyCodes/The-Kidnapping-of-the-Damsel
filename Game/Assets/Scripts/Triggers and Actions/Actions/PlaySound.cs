using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Action
{
    [SerializeField] AudioClip audioclip;
    [SerializeField] float volume;
    [SerializeField] bool playContinuously, playOneShot, playAtPoint;
    [SerializeField] Transform point;

    AudioSource audioSource;
    float timeToEnd;

    void OnEnable()
    {
        DisableTrigger();

        audioSource = GetComponent<AudioSource>();

        if(playAtPoint) 
            AudioSource.PlayClipAtPoint(audioclip, point.position, volume);

        else if(playOneShot)
            audioSource.PlayOneShot(audioclip, volume);
            
        else if(playContinuously && !audioSource.isPlaying)
            audioSource.Play();

        if (waitUntilEnd)
        {
            WaitForSeconds audioclipLength = new WaitForSeconds(audioclip.length);
            StartCoroutine(WaitToSignal(audioclipLength));
        }
        else
            SignalSequencer();

        AllowRepeat();
    }
}