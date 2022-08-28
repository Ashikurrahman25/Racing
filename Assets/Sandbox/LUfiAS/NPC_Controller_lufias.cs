using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller_lufias : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public Transform emojiPos;
    public float walkSpeed, runSpeed;
    public float waitTime = 3;
    public Transform cloud;
    public Vector3[] runToWherePos;

    public int behave = 1; // 0=idle, 1=explore, 2=happy, 3=angry , 4=turn off
    float t;
    bool flag = false;
    bool isIdle = true;

    float disctance;

    private void Start()
    {
        agent.speed = walkSpeed;
    }

    private void Update()
    {
        if (!flag)
        {
            CalculateDistance();
            if (isIdle)
            {
                if (t <= 0)
                {
                    t = waitTime;
                    behave = 1;
                    isIdle = false;
                }
                else
                {
                    t -= Time.deltaTime;
                }
            }
        }
        Emoji();
        if (behave == 0) Idle();
        else if (behave == 1) Explore();
        else if (behave == 2) Happy();
        else if (behave == 3) Angry();
    }
    
    void Emoji()
    {
        emojiPos.LookAt(Camera.main.transform.position);


        if (behave == 2) emojiPos.GetComponent<Animator>().Play("happyEmoji");
        else if (behave == 3) emojiPos.GetComponent<Animator>().Play("angryEmoji");
    }

    void Idle()
    {
        isIdle = true;
        agent.isStopped = true;
        anim.Play("Idle");
        behave = 4;
    }

    void Explore()
    {
        agent.SetDestination(new Vector3(Random.Range(-21,22), 0, Random.Range(10, 36)));
        anim.Play("explore");
        agent.isStopped = false;
        behave = 4;
    }

    void CalculateDistance()
    {
        disctance = agent.remainingDistance;
        
        if (disctance < 3)
        {
            behave = 0;
        }
    }

    void Happy()
    {
        agent.SetDestination(cloud.position);
        anim.Play("happy");
        agent.isStopped = false;
    }

    void Angry()
    {
        agent.SetDestination(runToWherePos[Random.Range(0, runToWherePos.Length)]);
        anim.Play("angry");
        agent.isStopped = false;
        behave = 4;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!flag)
        {
            if (other.CompareTag("cloud"))
            {
                agent.speed = runSpeed;
                behave = (int)Random.Range(2, 4);                
                flag = true;
            }
        }
    }

}
