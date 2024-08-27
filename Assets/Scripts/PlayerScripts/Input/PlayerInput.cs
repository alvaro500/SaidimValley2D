using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//#pragma warning disable IDE0060, IDE0059

public class PlayerInput : MonoBehaviour
{
    private Vector2 _moveInput;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private bool _isRunning = false;
    //[SerializeField] private bool _isGrounded;

    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerFlip _playerFlip;
    [SerializeField] private TouchingDirections _touchingDirections;
    public Vector2 MoveInput { get { return _moveInput; } private set { _moveInput = value; } }

    public bool IsMoving { get { return _isMoving; } private set { _isMoving = value;} }
    public bool IsRunning { get { return _isRunning; } private set { _isRunning = value;} }

    //private void OnEnable()
    //{
    //EventManager.Animate += PlayMovementAnimations;
    // EventManager.Animate += PlayWalkAnimation;
    // EventManager.Animate += PlayRunAnimation;
    //}

    // private void OnDisable()
    // {
    //EventManager.Animate -= PlayMovementAnimations;
    // EventManager.Animate -= PlayWalkAnimation;
    // EventManager.Animate -= PlayRunAnimation;
    //}

    //PlayAnimationPlayer replaces Update for animation checking
    // private void PlayMovementAnimations()
    // {
    //     _playerAnimation.AnimateWalk(_isMoving);
    //     _playerAnimation.AnimateRun(_isRunning);
    // }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        _isMoving = _moveInput != Vector2.zero;

        //Run moving Animation
        _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[0], _isMoving);

        _playerFlip.SetFacingDirection(_moveInput);
        //Debug.Log("IsMoving");
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

        //Debug.Log("IsRunning");

        //EventManager.NotifyAnimation();
        //PlayerAnimation.InvokeAnimation();

        //Run Running Animation
        _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[1], _isRunning);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started  && _touchingDirections.IsGrounded)
        {
            
        }
        //EventManager.NotifyAnimation();
        //PlayerAnimation.InvokeAnimation();
    }
}