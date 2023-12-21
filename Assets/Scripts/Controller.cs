using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
enum AnimStates
{
    Down = 2,
    Up = 0,
    Left = 3,
    Right = 1
}
public class Controller : MonoBehaviour
{
    public Animator animator;
    private int LastDirection = -1;
    public Rigidbody2D rb;
    [HideInInspector]
    public Vector2 vectorDir = Vector2.down;
    

    private Vector2 moveVector = Vector2.zero;
    [Range(1f, 50f)]
    public float moveSpeed = 1f;


    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    public void Move(Vector2 _moveVector)
    {
        moveVector = _moveVector;

        // Animation Management
        float x = moveVector.x;
        float y = moveVector.y;

        int actualDir;
        float characterSpeed = moveVector.magnitude;

        animator.SetFloat("Speed", moveSpeed);

        if (characterSpeed > 0.1)
        {
            vectorDir = moveVector;

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
