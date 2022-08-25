using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] roamPoints;
    private NPCController npcController;
    private void Awake()
    {
        npcController = Controller.self.npcController;

        npcController.spawnPoints = spawnPoints;
        npcController.roamPoints = roamPoints;
        npcController.InstantiateNPC(); //Instantiate All
    }
}
