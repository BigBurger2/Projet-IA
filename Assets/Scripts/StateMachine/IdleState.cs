using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.IO;



public class IdleState : State
{
    public float distance;
    [SerializeField] private Vector3[] pattern;
    [SerializeField] public GameObject player;
    [SerializeField] public bool patternOn;
    private int nextPoint;
    public float speed;
    [SerializeField] public NavMeshAgent agent;
    public double distancePlayer;
    public bool canSeeThePlayer;
    public ChaseState chaseState;
    public Rigidbody2D rbP;
    public Vector3[] Pattern
    {
        get { return pattern; }
        set { pattern = value; }
    }

    //public override void OnStart()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void OnStop()
    //{
    //    throw new System.NotImplementedException();
    //}
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (player == null) { player = GameObject.FindGameObjectWithTag("Player"); }

        //rb = GetComponent<Rigidbody2D>();
        rbP = player.GetComponent<Rigidbody2D>();


        if (pattern.Length < 2)
        {
            patternOn = true;
        }

        if (patternOn)
        {
            nextPoint = 1;
            transform.position = pattern[0];

            agent.SetDestination(pattern[nextPoint]);
            agent.speed = speed;
        }

    }

    public override State RunCurrentState() //Do()
    {
        distancePlayer = (transform.position - player.transform.position).magnitude;
        if (patternOn)
        {
            FollowPattern();
        }
        if (distancePlayer < chaseState.followDistance)
        {
            canSeeThePlayer = true;
        }
        if (canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    void FollowPattern()
    {
        distance = Vector2.Distance(transform.position, pattern[nextPoint]);
        /*destination = pattern[nextPoint] - transform.position;*/


        agent.SetDestination(pattern[nextPoint]);
        agent.speed = speed;

        if (distance < 2f)
        {
            nextPoint++;
            if (nextPoint == pattern.Length) nextPoint = 0;
        }


    }
}
