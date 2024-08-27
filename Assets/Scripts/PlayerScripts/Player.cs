using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0044

public class Player : MonoBehaviour
{
    //[SerializeField] private Rigidbody2D _rigidbody2D;
    //[SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerInputController _playerInputController;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private TouchingDirections _touchingDirections;

    // private void OnEnable()
    // {
    //     _playerAnimation.Animate += PlayMovementAnimations;
    // }

    // private void OnDisable()
    // {
    //     _playerAnimation.Animate -= PlayMovementAnimations;
    // }

    // private void Update()
    // {
   
    // }

    // Move player from right to left with input
    private void FixedUpdate()
    {
        _playerMovement.MovePlayer(_playerInputController.MoveDirection);
        _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[3], _playerMovement.PlayerRigidbody2D.velocity.y);
    }


    //PlayAnimationPlayer replaces Update for animation checking
    //private void PlayMovementAnimations()
    //{
        // _playerAnimation.AnimateWalk(_playerInput.IsMoving);
        // _playerAnimation.AnimateRun(_playerInput.IsRunning);
        // _playerAnimation.AnimateGrounded(_touchingDirections.IsGrounded);
    //}
}