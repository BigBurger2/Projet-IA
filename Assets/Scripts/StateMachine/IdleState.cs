using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.IO;


[RequireComponent(typeof(HpComponent))]
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
    private Vector2 initPos;
    public HpComponent hpComponent;
    public Vector3[] Pattern
    {
        get { return pattern; }
        set { pattern = value; }
    }
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        hpComponent = GetComponent<HpComponent>();
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
            initPos = transform.position;
            //transform.position = pattern[0];

            //agent.SetDestination(pattern[nextPoint]);
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
        if (hpComponent.GetCurrentHp() <= 0)
        {
            gameObject.GetComponent<Entity>()?.OnDeath();
            return this;
        }
        else
        {
            return this;
        }
    }

    void FollowPattern()
    {
        //distance = Vector2.Distance(transform.position, pattern[nextPoint]);
        /*destination = pattern[nextPoint] - transform.position;*/


        agent.SetDestination(initPos);
        agent.speed = speed;

        //if (distance < 2f)
        //{
        //    nextPoint++;
        //    if (nextPoint == pattern.Length) nextPoint = 0;
        //}


    }
}
