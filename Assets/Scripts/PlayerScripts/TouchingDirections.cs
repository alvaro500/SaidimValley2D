using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _capsuleCollider2D; //touchingcol
    [SerializeField] private ContactFilter2D _contactFilter2D; //Filter to make sure we collide with the correct layers or objects
    private RaycastHit2D[] _groundHits = new RaycastHit2D[5];
    private RaycastHit2D[] _wallHits = new RaycastHit2D[5];
    private RaycastHit2D[] _ceilingHits = new RaycastHit2D[5];
    [SerializeField] private float _groundDistance = 0.05f;
    [SerializeField] private float _wallDistance = 0.2f;
    [SerializeField] private float _ceilingDistance = 0.05f;

    [SerializeField] PlayerAnimation _playerAnimation;
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
            //PlayerAnimation.InvokeAnimation();

            //Run IsGrounded SubStateMachine
            _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[2], value);
        }
    }

    public bool _isOnWall;
    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;

            //Run isOnWall Animation
            _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[3], value);
        }
    }

    public bool _isOnCeiling;

    private Vector2 _wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
            //PlayerAnimation.InvokeAnimation();

            //Run isOnCeiling Animation
            _playerAnimation.RunAnimation(_playerAnimation.AnimationParameterHashes[4], value);
        }
    }

    void FixedUpdate()
    {
        //Cast collider to know if we are on the ground
        IsGrounded = _capsuleCollider2D.Cast(Vector2.down, _contactFilter2D, _groundHits, _groundDistance) > 0;

        //Cast collider to know if we are touching a wall
        IsOnWall = _capsuleCollider2D.Cast(_wallCheckDirection, _contactFilter2D, _wallHits, _wallDistance) > 0;

        //Cast collider to know if we are touching a ceilling
        IsOnCeiling = _capsuleCollider2D.Cast(Vector2.up, _contactFilter2D, _ceilingHits, _ceilingDistance) > 0;
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.blue;

    //     Vector3 capsuleColliderSizeY = new (0, _capsuleCollider2D.size.y, 0);
    //     Vector3 capsuleColliderHalfSizeY = capsuleColliderSizeY/2;
    //     Vector3 groundDistanceFromCollider = new (0, _groundDistance, 0);

    //     Gizmos.DrawRay(-capsuleColliderHalfSizeY, -groundDistanceFromCollider);
    // }
}