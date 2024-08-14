using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private bool _isFacingRight = true;
    [SerializeField] Transform _playerTransform;

    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }

        private set
        {
            if (_isFacingRight != value)
            {
                // Flip the local scale to make the player face the oposite direction
                _playerTransform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    public void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !_isFacingRight)
        {
            //Face the right
            IsFacingRight = true;

        }
        else if (moveInput.x < 0 && _isFacingRight)
        {
            //Face the left
            IsFacingRight = false;
        }
    }
}