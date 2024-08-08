using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0044

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMovement _playerMovement;

    // Move player from right to left with input
    void FixedUpdate()
    {
        _playerMovement.MovePlayer(_rigidbody2D, _playerInput.MoveInput);
    }
}