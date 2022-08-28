using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject npcPrefab;
    public Transform cloudCollider;
    public Transform[] spawnPoints;
    //public Transform[] roamPoints;

    public int npcAmount;


    private void Start()
    {

    }

    public void InstantiateNPC()
    {
        for (int i = 0; i < npcAmount; i++)
        {
            //in future will use object pooling
            GameObject npc = Instantiate(npcPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            npc.GetComponent<NPC_Controller_lufias>().cloud = cloudCollider;
        }
    }


   

}
