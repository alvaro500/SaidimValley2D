using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _capsuleCollider2D; //touchingcol
    [SerializeField] private ContactFilter2D _contactFilter2D; //Filter to make sure we collide with the correct layers or objects
    private RaycastHit2D[] _groundHits = new RaycastHit2D[5];
    [SerializeField] private float _groundDistance = 0.05f;
    public bool _isGrounded;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            PlayerAnimation.InvokeAnimation();
        }
    }

    //[SerializeField] private PlayerAnimation _playerAnimation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Cast collider to know if we are on the ground or touching a wall
        IsGrounded = _capsuleCollider2D.Cast(Vector2.down, _contactFilter2D, _groundHits, _groundDistance) > 0;
    }
}