using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInputActionsScript _playerInputActions;

    private InputAction _moveAction;
    private InputAction _runAction;
    private InputAction _jumpAction;
    private InputAction _attackAction;

    [SerializeField] private bool _isMoving = false;
    [SerializeField] private bool _isRunning = false;

    [SerializeField] PlayerAnimation _playerAnimation;
    [SerializeField] PlayerFlip _playerFlip;
    [SerializeField] private TouchingDirections _touchingDirections;
    [SerializeField] private PlayerMovement _playerMovement;
    public bool IsMoving { get => _isMoving; set { _isMoving = MoveDirection != Vector2.zero; } }

    public bool IsRunning { get => _isRunning; set => _isRunning = value; }
    public Vector2 MoveDirection { get; private set; }

    private void Awake()
    {
        _playerInputActions = new PlayerInputActionsScript();
    }

    private void OnEnable()
    {
        _moveAction = _playerInputActions.Player.Move;
        _moveAction.started += callbackContext => CheckInputForMovementDirection();
        // {
        //     MoveDirection = _moveAction.ReadValue<Vector2>();
        //     Debug.Log("Moviendose (Método anónimo)");
        //     //Run Move Animation
        //     _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[0], _isMoving);
        //     _playerFlip.SetFacingDirection(MoveDirection);
        //     _isMoving = MoveDirection != Vector2.zero;

        // };
        _moveAction.canceled += callbackContext => CheckInputForMovementDirection();
        _moveAction.Enable();

        _runAction = _playerInputActions.Player.Run;
        _runAction.started += callbackContext => CheckInputForRun(callbackContext);
        _runAction.canceled += callbackContext => CheckInputForRun(callbackContext);
        _runAction.Enable();

        _jumpAction = _playerInputActions.Player.Jump;
        _jumpAction.started += callbackContext => CheckInputForJump(callbackContext);
        _jumpAction.Enable();

        _attackAction= _playerInputActions.Player.Attack;
        _attackAction.started += callbackContext => CheckInputForAttack(callbackContext);
        _attackAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.performed -= callbackContext => CheckInputForMovementDirection();
        _moveAction.canceled -= callbackContext => CheckInputForMovementDirection();
        _moveAction.Disable();

        _runAction.started -= callbackContext => CheckInputForRun(callbackContext);
        _runAction.Disable();

        _jumpAction.started -= callbackContext => CheckInputForJump(callbackContext);
        _jumpAction.Disable();


        _attackAction.started -= callbackContext => CheckInputForAttack(callbackContext);
        _attackAction.Disable();
    }

    // private void OnMove(InputAction.CallbackContext context)
    // {
    //     Debug.Log("MoveFromInputDirection");
    //     MoveDirection = _moveAction.ReadValue<Vector2>();

    //_isMoving = MoveDirection != Vector2.zero;

    //Run Move Animation
    //_playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[0], _isMoving);
    //}

    private void CheckInputForMovementDirection()
    {
        //Detect input for player direction and movement
        MoveDirection = _moveAction.ReadValue<Vector2>();

        //Check if the player is moving or not
        _isMoving = MoveDirection != Vector2.zero;

        //Run Move Animation
        _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[0], _isMoving);

        //Determine where the player is looking
        _playerFlip.SetFacingDirection(MoveDirection);
    }

    private void CheckInputForRun(InputAction.CallbackContext context)
    {
        //Debug.Log("Run");
        
        if (context.started)
        {
            _isRunning = true;

        }
        else if (context.canceled)
        {
            _isRunning = false;
        }

        //Run Running Animation
        _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[1], _isRunning);
    }

    private void CheckInputForJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump");
        if (context.started && _touchingDirections.IsGrounded)
        {
            //Run Jump animation with trigger
            _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[4]);
            _playerMovement.Jump();
        }
    }

        private void CheckInputForAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }
}