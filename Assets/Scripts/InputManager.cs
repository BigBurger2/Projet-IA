using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public CustomInput input;
    
    public Controller ctr;
    public Shoot shoot;

    private void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Shoot.performed += ctx => OnShoot();
        //input.Player.Move.performed += ctx => PlayerMove(ctx);
        //input.Player.Move.canceled += ctx => OnStop(ctx);

    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Shoot.performed -= ctx => OnShoot();

        //input.Player.Move.performed -= ctx => PlayerMove(ctx);
        //input.Player.Move.canceled -= ctx => OnStop(ctx);

    }

    private void FixedUpdate()
    {
        
    }


    public void PlayerMove(InputAction.CallbackContext value)
    {
        Vector2 toSend = value.ReadValue<Vector2>();
        ctr.Move(toSend);
    }

    public void OnShoot()
    {
        shoot.Action();
    }
}
