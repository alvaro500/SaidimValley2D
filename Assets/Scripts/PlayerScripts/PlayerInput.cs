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
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerFlip _playerFlip;
    public Vector2 MoveInput { get { return _moveInput; } private set { _moveInput = value; } }

    public bool IsMoving { get { return _isMoving; } set { _isMoving = value; /*_playerAnimation.AnimateWalk(value);*/} }
    public bool IsRunning { get { return _isRunning; } set { _isRunning = value;/*_playerAnimation.AnimateRun(value);*/ } }


    private void OnEnable()
    {
        EventManager.Animate += PlayMovementAnimations;
        // EventManager.Animate += PlayWalkAnimation;
        // EventManager.Animate += PlayRunAnimation;
    }

    private void OnDisable()
    {
        EventManager.Animate -= PlayMovementAnimations;
        // EventManager.Animate -= PlayWalkAnimation;
        // EventManager.Animate -= PlayRunAnimation;
    }

    //PlayAnimationPlayer replaces Update for animation checking
    private void PlayMovementAnimations()
    {
        _playerAnimation.AnimateWalk(_isMoving);
        _playerAnimation.AnimateRun(_isRunning);
    }

    // private void PlayWalkAnimation()
    // {
    //     _playerAnimation.AnimateWalk(_isMoving);
    // }

    // private void PlayRunAnimation()
    // {
    //     _playerAnimation.AnimateRun(_isRunning);
    // }

    
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        _isMoving = _moveInput != Vector2.zero;

        EventManager.NotifyAnimation();

        _playerFlip.SetFacingDirection(_moveInput);

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

        EventManager.NotifyAnimation();
    }
}