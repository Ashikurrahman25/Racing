using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovements : MonoBehaviour
{
    private int walkingAnimID = Animator.StringToHash("Walking");
    private int runningAnimID = Animator.StringToHash("Running");

    public bool travelling;
    public bool waiting;
    public bool patrolWaiting;
    public bool patrolforward;
    public float timeToWait;
    public float switchPorbability;
    public float waitTimer;
    public int currentPatrolIndex;

    public Animator npcAnim;
    public NavMeshAgent navmesh;

    public Transform[] patrolPoints;

    private void Start()
    {
        patrolPoints = Controller.self.npcController.roamPoints;

        if (navmesh == null)
            navmesh = this.GetComponent<NavMeshAgent>();

        if(patrolPoints != null && patrolPoints.Length >= 2)
        {
            npcAnim.SetBool(walkingAnimID, true);
            currentPatrolIndex = 0;
            SetDestination();
        }
    }
    private void Update()
    {
       if(travelling && navmesh.remainingDistance <= .5f)
        {
            travelling = false;

            if (npcAnim.GetBool(walkingAnimID))
                npcAnim.SetBool(walkingAnimID, false);

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer >= timeToWait)
            {
                waiting = false;
                ChangePatrolPoint();
                SetDestination();
            }
        }
    }


    void SetDestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            targetVector.x += Random.Range(5, -5);
            targetVector.z += Random.Range(5, -5);

            navmesh.SetDestination(targetVector);
            travelling = true;
        }


        if (!npcAnim.GetBool(walkingAnimID))
            npcAnim.SetBool(walkingAnimID, true);

    }

    void ChangePatrolPoint()
    {
        if (Random.Range(0f, 1f) <= switchPorbability)
            patrolforward = !patrolforward;

        if (patrolforward)
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        else
        {
            if (--currentPatrolIndex < 0)
                currentPatrolIndex = patrolPoints.Length - 1;
        }
       
    }
}
