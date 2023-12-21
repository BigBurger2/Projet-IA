using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    public CustomInput input;
    
    public Controller ctr;
    public Shoot shoot;
    public PauseManager pauseManager;

    private void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Shoot.performed += ctx => OnShoot();
        input.Player.MenuPause.performed += ctx => Pause();
        input.Player.Shoot.canceled += ctx => OnStopShoot();
        //input.Player.Move.performed += ctx => PlayerMove(ctx);
        //input.Player.Move.canceled += ctx => OnStop(ctx);

    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Shoot.performed -= ctx => OnShoot();
        input.Player.MenuPause.performed -= ctx => Pause();
        input.Player.Shoot.canceled -= ctx => OnStopShoot();

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

    public void Pause()
    {
        pauseManager.Pause();
    }
    
    public void OnStopShoot()
    {
        shoot.Stop();
    }
}
