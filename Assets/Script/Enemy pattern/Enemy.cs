using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rbP;
    private Rigidbody2D rb;
    [SerializeField] private Vector3[] pattern;
    [SerializeField] public bool patternOn;
    [SerializeField] private bool agressive;
    [SerializeField] private bool savage;
    [SerializeField] public GameObject player;

    private Vector3 destination;
    private float distance;
    private int nextPoint;
    public float speed = 10f;
    public Vector3[] Pattern
    {
        get { return pattern; }
        set { pattern = value; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbP = player.GetComponent<Rigidbody2D>();

        nextPoint = 1;
        transform.position = pattern[0];
        destination = pattern[nextPoint] - transform.position;
        distance = Vector2.Distance(transform.position, pattern[nextPoint]);
        rb.velocity = destination.normalized * speed;
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

    void Update()
    {
        if (patternOn)
        {

            if (distance < 2f)
            {
                nextPoint++;

                if (nextPoint == pattern.Length) nextPoint = 0;

                destination = pattern[nextPoint] - transform.position;
            }
            distance = Vector2.Distance(transform.position, pattern[nextPoint]);
            rb.velocity = destination.normalized * speed;


        }
        else if (agressive)
        {
            destination = rbP.position - (Vector2)transform.position;
            rb.velocity = destination.normalized * speed;
        }
        else if (savage)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 10f)
            {
                destination = player.transform.position - transform.position;
                rb.velocity = destination.normalized * speed * -1;
            }
            else rb.velocity = new Vector2(0, 0);
        }
        else rb.velocity = new Vector2(0, 0);
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
            Pattern[j] = new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 4f), 0);
            patternOn = true;
        }
    }
}