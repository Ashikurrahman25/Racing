using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateController : MonoBehaviour
{

    private bool isContinuousPlaying = false;

    public void PlayContinuous(bool repeat) 
    {
        if (isContinuousPlaying) return;
        isContinuousPlaying = true;
        MMVibrationManager.ContinuousHaptic(0.3f, 0.8f, 2f, HapticTypes.None, this);
        if (repeat) 
        {
            StopCoroutine(OnContinuousVibrateEnd());
            StartCoroutine(OnContinuousVibrateEnd());
        }
    }

    public void StopContinuous()
    {
        isContinuousPlaying = false;
        MMVibrationManager.StopContinuousHaptic(true);
    }

    IEnumerator OnContinuousVibrateEnd()
    {
        yield return WaitFor.two;
        if (isContinuousPlaying) PlayContinuous(true);
    }
}
