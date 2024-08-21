using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0044

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private TouchingDirections _touchingDirections;

    private void OnEnable()
    {
        _playerAnimation.Animate += PlayMovementAnimations;
    }

    private void OnDisable()
    {
        _playerAnimation.Animate -= PlayMovementAnimations;
    }

    // Move player from right to left with input
    private void FixedUpdate()
    {
        _playerMovement.MovePlayer(_rigidbody2D, _playerInput.MoveInput);
    }


    //PlayAnimationPlayer replaces Update for animation checking
    private void PlayMovementAnimations()
    {
        _playerAnimation.AnimateWalk(_playerInput.IsMoving);
        _playerAnimation.AnimateRun(_playerInput.IsRunning);
        _playerAnimation.AnimateGrounded(_touchingDirections.IsGrounded);
    }
}