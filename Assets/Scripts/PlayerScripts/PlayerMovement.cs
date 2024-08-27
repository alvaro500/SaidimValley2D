using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInputController _playerInputController;

    //[SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 8f;

    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    public Rigidbody2D PlayerRigidbody2D { get => _playerRigidbody2D; set => _playerRigidbody2D = value; }

    //Jump variables
    [SerializeField] private float _jumpImpulse = 10f;

    public float CurrentMoveSpeed
    {
        get
        {
            if (_playerInputController.IsMoving)
            {
                if (_playerInputController.IsRunning)
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

    public void MovePlayer(Vector2 moveInput)
    {
        _playerRigidbody2D.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, _playerRigidbody2D.velocity.y);
    }

    public void Jump()
    {
        _playerRigidbody2D.velocity = new Vector2(_playerRigidbody2D.velocity.x, _jumpImpulse);
    }
}