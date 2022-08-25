using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RainAudio : MonoBehaviour
{
    public float fadeTime = 0.25f;
    public float rainVolume = 1;
    public AudioClip rainImpactSound;

    private AudioSource audioSource;
    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();          
        audioController = Controller.self.audioController;
    }

    public void PlayRainImpactSound()
    {
        audioSource.PlayOneShot(rainImpactSound);
    }

    public void PlayRainSoundLoop()
    {
        audioSource.clip = rainImpactSound;
        audioSource.loop = true;
        if(!audioSource.isPlaying) audioSource.Play();
        audioController.FadeVolume(audioSource, rainVolume, fadeTime);
    }

    public void StopRainSoundLoop()
    {
        audioController.FadeVolume(audioSource, 0, fadeTime);        
    }

    public bool IsPlayingLoop()
    {
        return audioSource.isPlaying;
    }
}
