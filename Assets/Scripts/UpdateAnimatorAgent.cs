using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(NavMeshAgent))]
public class UpdateAnimatorAgent : MonoBehaviour
{

    private Animator animator;

    private int LastDirection = -1;

    private Vector3 lastPosition;

    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 moveVector = transform.position - lastPosition;
        UpdateAnimDatas(moveVector);
        lastPosition = transform.position;
    }

    public void UpdateAnimDatas(Vector2 moveVector)
    {
        int actualDir;
        
        float characterSpeed = moveVector.magnitude;

        if (characterSpeed > 0)
        {
            animator.SetFloat("Speed", agent.speed);
        }
        else
        {
            animator.SetFloat("Speed", 0);

        }

        float x = moveVector.x;
        float y = moveVector.y;

        if (characterSpeed > 0)
        {
            if (((y > 0) ? 1 : -1) * y < ((x > 0) ? 1 : -1) * x)
            {
                if (x > 0)
                {
                    actualDir = (int)AnimStates.Right;
                }
                else
                {
                    actualDir = (int)AnimStates.Left;
                }
            }
            else if (y > 0)
            {
                actualDir = (int)AnimStates.Up;
            }
            else
            {
                actualDir = (int)AnimStates.Down;
            }

            if (actualDir != LastDirection)
            {
                animator.SetTrigger("ChangeState");
                animator.SetInteger("State", actualDir);
            }
        }
    }
}
