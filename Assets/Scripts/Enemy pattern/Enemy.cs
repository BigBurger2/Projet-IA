using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rbP;
    //private Rigidbody2D rb;
    [SerializeField] private Vector3[] pattern;
    [SerializeField] public bool patternOn;
    [SerializeField] private bool agressive;
    [SerializeField] private bool savage;
    [SerializeField] public GameObject player;
    [SerializeField] private NavMeshAgent agent;

    public float speed;
    public float fleeSpeed;
    public float followSpeed;
    public float followDistance = 10f;
    public float followDistanceCancel = 10f;
    public float fleeDistance = 10f;
    bool flee = false;

    private Vector3 destination;
    private float distance;
    private int nextPoint;

    public Vector3[] Pattern
    {
        get { return pattern; }
        set { pattern = value; }
    }

    public bool Agressive { get => agressive; set => agressive = value; }
    private void Awake()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start()
    {
        if (player == null) { player = GameObject.FindGameObjectWithTag("Player"); }

        //rb = GetComponent<Rigidbody2D>();
        rbP = player.GetComponent<Rigidbody2D>();

        nextPoint = 1;
        transform.position = pattern[0];
        /*destination = pattern[nextPoint] - transform.position;
        distance = Vector2.Distance(transform.position, pattern[nextPoint]);*/
        //rb.velocity = destination.normalized * speed;

        agent.SetDestination(pattern[nextPoint]);
        agent.speed = speed;

    }

    public void OnDrawGizmos()
    {
        if (patternOn)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (i + 1 == (int)pattern.Length) Gizmos.DrawLine(pattern[i], pattern[0]);
                else Gizmos.DrawLine(pattern[i], pattern[i + 1]);
            }
        }
    }

    private void FixedUpdate()
    {
        if (patternOn) FollowPattern();
        if (agressive) FollowPlayer();
        else if (savage) FleePlayer();

        //else rb.velocity = new Vector2(0, 0);
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

/*
        rb.velocity = destination.normalized * speed;*/


    }

    void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, rbP.position);

        if (distance < followDistance)
        {
            agent.SetDestination(rbP.position);
            agent.speed = followSpeed;

            /*destination = player.transform.position - transform.position;
            rb.velocity = destination.normalized * followSpeed;*/
        }
        //else destination = pattern[nextPoint] - transform.position;

    }

    void FleePlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < fleeDistance) flee = true;
        if (flee)
        {
            destination = rbP.position - (Vector2)transform.position;
            //rb.velocity = destination.normalized * fleeSpeed * -1;
        }
        else destination = pattern[nextPoint] - transform.position;
        if (distance > fleeDistance * 2) flee = false;
    }

    void Update()
    {

    }

    public void newEnemy(Enemy Enemy, int nbrEnemy)
    {
        for (int i = 0; i < nbrEnemy; i++)
        {
            Instantiate(Enemy);
            randomPattern();
        }
    }

    private void randomPattern()
    {
        int path = Random.Range(3, 7);
        pattern = new Vector3[path];
        for (int j = 0; j < path; j++)
        {
            Pattern[j] = new Vector3(Random.Range(-50f, 50f), Random.Range(-10f, 10f), 0);
            patternOn = true;
        }
    }
}