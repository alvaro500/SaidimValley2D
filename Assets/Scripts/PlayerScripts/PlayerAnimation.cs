using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public Animator Animator { get => _animator; set => _animator = value; }

    //Int for hash code animations
    private int _walkAnimationHashCode;
    private int _runAnimationHashCode;

    private void Awake()
    {
        // StringToHash helps optimize animations a bit
        _walkAnimationHashCode = Animator.StringToHash("isMoving");
        _runAnimationHashCode = Animator.StringToHash("isRunning");
        
        // for (int i = 0; i < _animator.parameters.Length; i++)
        // {
        //     Debug.Log(_animator.parameters[i].name);
        // }
    }

    public void AnimateWalk(bool isMoving)
    {
        _animator.SetBool(_walkAnimationHashCode, isMoving);
    }

    public void AnimateRun(bool isRunning)
    {
        _animator.SetBool(_runAnimationHashCode, isRunning);
    }
}