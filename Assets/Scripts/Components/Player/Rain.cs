using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject rainImpactParticle;
    public ParticleSystem rainFallEffect;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = Controller.self.gameController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private RaycastHit hit;

    public void FallRain()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 50))
        {
            //GameObject impactGo = gameController.objectPool.GetPooledObject("RainImpact");
            rainImpactParticle.transform.position = hit.point;
            rainImpactParticle.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }

}
