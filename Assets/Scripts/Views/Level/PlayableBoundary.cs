using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableBoundary : MonoBehaviour
{
    public Transform[] xPlayableArea;
    public Transform[] zPlayableArea;

    private void Awake()
    {
        var playerMovement = Controller.self.playerController.playerMovement;
        playerMovement.xPlayableArea = xPlayableArea;
        playerMovement.zPlayableArea = zPlayableArea;
    }
}
