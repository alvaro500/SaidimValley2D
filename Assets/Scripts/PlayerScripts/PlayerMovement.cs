using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0044

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private bool _isMoving = false;
    //[SerializeField] private bool _isRunning = false;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 8f;

    public float CurrentMoveSpeed
    {
        get
        {
            if (_playerInput.IsMoving)
            {
                if (_playerInput.IsRunning)
                {
                    return _runSpeed;
                }
                else
                {
                    return _walkSpeed;
                }
            }
            else
            {
                //Idle speed is 0
                return 0;
            }
        }
    }

    // void FixedUpdate()
    // {
    //     MovePlayer();
    // }

    public void MovePlayer(Rigidbody2D rigidbody2D, Vector2 moveInput)
    {
        rigidbody2D.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rigidbody2D.velocity.y);
    }
}