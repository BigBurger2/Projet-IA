using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public CustomInput input;
    [Range(1f, 50f)]
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveVector = Vector2.zero;

    public Animator animator;

    private int LastDirection = -1;

    enum AnimStates
    {
        Down = 2,
        Up = 0,
        Left = 3,
        Right = 1
    }

    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        //input.Player.Move.performed += ctx => PlayerMove(ctx);
        //input.Player.Move.canceled += ctx => OnStop(ctx);

    }

    private void OnDisable()
    {
        input.Disable();
        //input.Player.Move.performed -= ctx => PlayerMove(ctx);
        //input.Player.Move.canceled -= ctx => OnStop(ctx);

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }


    public void PlayerMove(InputAction.CallbackContext value)
    {
        Debug.Log("move");
        moveVector = value.ReadValue<Vector2>();


        // Animation Management
        float x = moveVector.x;
        float y = moveVector.y;

        int actualDir;
        float characterSpeed = moveVector.magnitude;

        animator.SetFloat("Speed", characterSpeed);

        Debug.Log(characterSpeed);

        if (characterSpeed > 0.1)
        {
            if ( ((y > 0) ? 1 : -1) * y < ((x > 0) ? 1 : -1) * x)
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


    private void OnStop(InputAction.CallbackContext value)
    {
        rb.velocity = Vector2.zero;
    }
}
