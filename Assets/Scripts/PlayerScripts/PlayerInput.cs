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
    [SerializeField] private PlayerFlip _playerFlip;
    //Animator animator;
    public Vector2 MoveInput { get { return _moveInput; } private set { _moveInput = value; } }

    public bool IsMoving { get { return _isMoving; } set { _isMoving = value; /*_playerAnimation.AnimateWalk(value);*/} }
    public bool IsRunning { get { return _isRunning; } set { _isRunning = value;/*_playerAnimation.AnimateRun(value);*/ } }


    // Start is called before the first frame update
    private void OnEnable()
    {
        EventManager.Animate += PlayMovementAnimations;
    }

    private void OnDisable()
    {
        EventManager.Animate -= PlayMovementAnimations;
    }

    //PlayAnimationPlayer replaces Update for animation checking
    void PlayMovementAnimations()
    {
        _playerAnimation.AnimateWalk(_isMoving);
        _playerAnimation.AnimateRun(_isRunning);
    }

    #pragma warning disable IDE0060, IDE0059

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
    }
}