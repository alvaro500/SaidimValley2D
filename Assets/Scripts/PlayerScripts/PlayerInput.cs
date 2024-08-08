using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{


    private Vector2 _moveInput;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private bool _isRunning = false;
    [SerializeField] private PlayerAnimation _playerAnimation;
    public Vector2 MoveInput { get { return _moveInput; } private set { _moveInput = value; } }

    public bool IsMoving { get { return _isMoving; } set { _isMoving = value; /*_playerAnimation.AnimateWalk(value);*/} }
    public bool IsRunning { get { return _isRunning; } set { _isRunning = value; /*_playerAnimation.AnimateRun(value);*/ } }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _playerAnimation.AnimateWalk(_isMoving);
        _playerAnimation.AnimateRun(_isRunning);
    }

#pragma warning disable IDE0060, IDE0059

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        _isMoving = _moveInput != Vector2.zero;

        //SetFacingDirection(moveInput);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isRunning = true;
        }
        else if (context.canceled)
        {
            _isRunning = false;
        }
    }
}