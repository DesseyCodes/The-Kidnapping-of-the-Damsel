using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound_action : Action
{
    [SerializeField] AudioClip audioclip;
    [SerializeField] float volume;
    [SerializeField] bool playContinuously, playOneShot, playAtPoint;
    [SerializeField] Transform point;

    AudioSource audioSource;
    float timeToEnd;

    void Start()
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
            timeToEnd = secondsToWait;
        else
            timeToEnd = 0;
    }
    
    void Update()
    {
        if(timeToEnd <= 0 && canSignal)
        {
            SignalActionSequencer();
            canSignal = false;
        }
        else if(timeToEnd > 0)
        {
            timeToEnd -= Time.deltaTime;
        }
    }
    //Using Update checks instead of WaitUntilEnd
    protected override IEnumerator WaitUntilEnd()
    {
        secondsToWait = audioclip.length;
        yield return null;
        StartCoroutine(base.WaitUntilEnd());
    }
}