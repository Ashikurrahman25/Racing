using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class AudioController : MonoBehaviour
{
    [Header("Volumes")]
    public float bgVolume;

    [Header("Audio Clips")]
    public AudioClip bgSound;
    public AudioClip successEndSound;
    public AudioClip failEndSound;
    [Space]

    [Header("Audio Sources")]
    public AudioSource globalAudioSource;


    public void PlayBG()
    {
        //mute audio
        FadeVolume(globalAudioSource, 0, 0.1f, () => 
        {
            //stop, change clip and play again
            globalAudioSource.Stop(); 
            globalAudioSource.clip = bgSound;
            globalAudioSource.Play();
            //fade volume to audible range
            FadeVolume(globalAudioSource, bgVolume, 0.25f);
        });
    }

    public void StopBG()
    {
        FadeVolume(globalAudioSource, 0, 0.5f, () => globalAudioSource.clip = null);
    }

    public void PlaySuccessEndSound()
    {

    }

    public void StopSuccessEndSound()
    {

    }

    public void PlayFailEndSound()
    {

    }

    public void StopFailEndSound()
    {

    }

    public void FadeVolume(AudioSource audioSouce, float targetValue, float time, Action callback = null)
    {
        DOTween.To(() => audioSouce.volume, x => audioSouce.volume = x, targetValue, time).
            OnComplete(() => callback?.Invoke());        
    }
}
