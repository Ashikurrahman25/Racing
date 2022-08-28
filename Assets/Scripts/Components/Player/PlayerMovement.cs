using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = InputWrapper;

public class PlayerMovement : MonoBehaviour
{
    public GameObject colliderTrigger;
    public float timeForFallingWater;

    public Transform[] xPlayableArea;
    public Transform[] zPlayableArea;

    public FloatingJoystick joystick;
    public bool canMove = false;
    public float speed;

    private Rain rain;
    private RainAudio rainAudio;

    private Vector3 direction;
    private Vector3 nextPos;

    private VibrateController vibrateController;
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        rain = GetComponent<Rain>();
        rainAudio = GetComponent<RainAudio>();
        vibrateController = Controller.self.vibrateController;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        direction.y = 0;

        nextPos = transform.position + direction;

        //Make sure we are inside playable area
        if (nextPos.x < xPlayableArea[0].position.x || nextPos.x > xPlayableArea[1].position.x)
            direction.x = 0;

        if (nextPos.z < zPlayableArea[0].position.z || nextPos.z > zPlayableArea[1].position.z)
            direction.z = 0;

        transform.Translate(direction * Time.deltaTime * speed);

        if (Input.touchCount > 0)
        {
            rain.FallRain(); //fall rain     
            MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            if (!rain.rainFallEffect.isPlaying) rain.rainFallEffect.Play(true);
            if (!flag)
            {
                Invoke(nameof(ColliderOn), timeForFallingWater);
                flag = true;
            }
        }
        else
        {
            rain.rainFallEffect.Stop(false);
            if (flag)
            {
                Invoke(nameof(ColliderOff), timeForFallingWater);
                flag = false;
            }
        }

        if (Input.touchCount == 0) return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rainAudio.PlayRainSoundLoop(); // turn on rain sound
            // vibrateController.PlayContinuous(true); // vibrate
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            rainAudio.StopRainSoundLoop();
            // vibrateController.StopContinuous(); 
        }

        
    }

    void ColliderOn()
    {
        if (!colliderTrigger.activeInHierarchy) colliderTrigger.SetActive(true);
    }

    void ColliderOff()
    {
        colliderTrigger.SetActive(false);
    }
}
