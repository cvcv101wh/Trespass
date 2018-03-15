using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardPatrol : MonoBehaviour {
    private float waitTimer = 5f;
    private float restartTimer = 0f;
    public float waitDuration = 5f;
    public Transform[] points;
    public int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    private bool startTimer = false;
    private bool startRestart = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

       // GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (GetComponent<Animator>().GetBool("Move"))
        {

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
            else if(destPoint==0 && restartTimer<=0)
            {
                agent.isStopped = true;
                gameObject.GetComponent<Animator>().SetBool("Move", false);
                gameObject.GetComponents<AudioSource>()[0].Stop();
                startTimer = true;
            }
        }

        if(startTimer)
        {
            if(waitTimer >= 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                startTimer = false;
                waitTimer = waitDuration;
                gameObject.GetComponent<Animator>().SetBool("Move", true);
                gameObject.GetComponents<AudioSource>()[0].Play();
                agent.isStopped = false;
                startRestart = true;
                restartTimer = 5;
            }
        }

        if(startRestart)
        {
            if (restartTimer > 0)
            {
                restartTimer -= Time.deltaTime;
            }
            else
            {
                startRestart = false;
                restartTimer = 0;
        }
        }
       
    }
}
