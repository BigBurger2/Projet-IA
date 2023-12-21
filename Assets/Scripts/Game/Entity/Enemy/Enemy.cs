using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.AI;

public class Enemy : Entity
{
    private Rigidbody2D rbP;
    //private Rigidbody2D rb;
    [SerializeField] private List<Vector3> pattern;
    [SerializeField] public bool patternOn;
    [SerializeField] private bool agressive;
    [SerializeField] private bool savage;
    [SerializeField] public GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject healthBar;


    public float speed;
    public float fleeSpeed;
    public float followSpeed;
    public float followDistance = 10f;
    public float followDistanceCancel = 10f;
    public float fleeDistance = 10f;
    bool flee = false;

    private Vector3 destination;
    private float distance;
    private float distancePlayer;
    private int nextPoint;

    private List<GameObject> healthBarChild;

    public List<Vector3> Pattern
    {
        get { return pattern; }
        set { pattern = value; }
    }

    public bool Agressive { get => agressive; set => agressive = value; }


    private void Awake()
    {
        healthBarChild = new List<GameObject>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;


        for (int i = 0; i < healthBar.transform.childCount; i++)
        {
            GameObject temp = healthBar.transform.GetChild(i).gameObject;
            temp.SetActive(false);
            healthBarChild.Add(temp);
        }
    }

    void Start()
    {
        if (player == null) { player = GameObject.FindGameObjectWithTag("Player"); }
        GetComponent<ProjectileHurt>().Invincible = true;
        //rb = GetComponent<Rigidbody2D>();
        rbP = player.GetComponent<Rigidbody2D>();


        if (pattern.Count < 2)
        {
            if (pattern.Count == 0)
            {
                pattern.Add(transform.position);
            }
            patternOn = false;
        }

        transform.position = pattern[0];
        if (patternOn)
        {

            

            nextPoint = 1;
            /*destination = pattern[nextPoint] - transform.position;
            distance = Vector2.Distance(transform.position, pattern[nextPoint]);*/
            //rb.velocity = destination.normalized * speed;

            agent.SetDestination(pattern[nextPoint]);
            agent.speed = speed;
        }

    }

    public void OnDrawGizmos()
    {
        if (patternOn)
        {
            for (int i = 0; i < pattern.Count; i++)
            {
                if (i + 1 == (int)pattern.Count) Gizmos.DrawLine(pattern[i], pattern[0]);
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
            if (nextPoint == pattern.Count) nextPoint = 0;
        }

/*
        rb.velocity = destination.normalized * speed;*/


    }

    void FollowPlayer()
    {
        distancePlayer = Vector2.Distance(transform.position, rbP.position);
        distance = Vector2.Distance(transform.position, pattern[nextPoint]);


        if (distancePlayer < followDistance)
        {
            agent.SetDestination(rbP.position);
            agent.speed = followSpeed;

            foreach (GameObject child in healthBarChild)
            {
                child.SetActive(true);
            }
        }
        else if (distance > 0.2f && !patternOn)
        {
            foreach (GameObject child in healthBarChild)
            {
                child.SetActive(false);
            }

            agent.SetDestination(pattern[nextPoint]);
            agent.speed = speed;
        }
        else
        {
            foreach (GameObject child in healthBarChild)
            {
                child.SetActive(false);
            }
        }
    }

    void FleePlayer()
    {
        distancePlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distancePlayer < fleeDistance) flee = true;
        if (flee)
        {
            destination = rbP.position - (Vector2)transform.position;
            //rb.velocity = destination.normalized * fleeSpeed * -1;
        }
        else destination = pattern[nextPoint] - transform.position;
        if (distancePlayer > fleeDistance * 2) flee = false;
    }

    
    public void newEnemy(Enemy Enemy, int nbrEnemy)
    {
        for (int i = 0; i < nbrEnemy; i++)
        {
            Instantiate(Enemy);
            //randomPattern();
        }
    }

/*    private void randomPattern()
    {
        int path = Random.Range(3, 7);
        pattern = new Vector3[path];
        for (int j = 0; j < path; j++)
        {
            Pattern[j] = new Vector3(Random.Range(-50f, 50f), Random.Range(-10f, 10f), 0);
            patternOn = true;
        }
    }*/


    public override void OnDeath()
    {
        // -1 oponent dans le game manager
        //animator death 
        //Drop Loot
        Debug.Log("DID YOU JUST KILL THIS WABBIT");
        CallEvent();
        Destroy(gameObject);
    }
}