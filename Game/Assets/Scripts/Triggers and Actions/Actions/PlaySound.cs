using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Action
{
    [SerializeField] AudioClip audioclip;
    [Tooltip ("Volume scale.")]
    [SerializeField] float volume;
    [Tooltip ("Play continuously needs an audiosource with an audioclip.\nPlay oneshot needs an audiosource and the audioclip up here.\nPlay at point only needs the audioclip.")]
    [SerializeField] bool playContinuously, playOneShot, playAtPoint;
    [Tooltip ("Point for 'play at point'")]
    [SerializeField] Transform point;

    void OnEnable()
    {
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
            SignalToContinue();
    }

    IEnumerator WaitToSignal(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SignalToContinue();
    }
    
}