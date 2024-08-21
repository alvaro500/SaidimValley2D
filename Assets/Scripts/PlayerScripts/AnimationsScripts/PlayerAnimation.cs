using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static PlayerAnimation _instance;
    [SerializeField] private Animator _animator;

    //public Animator Animator { get => _animator; set => _animator = value; }

    //Int for hash code animations
    private int _walkAnimationHashCode;
    private int _runAnimationHashCode;
    private int _groundStateHashCode;

    private int[] _animationHashCode;

    //Events for Animations

    public delegate void AnimationLoader();

    public event AnimationLoader Animate;

    private void Awake()
    {
        _instance = this;
        // StringToHash helps optimize animations a bit
        _walkAnimationHashCode = Animator.StringToHash("isMoving");
        _runAnimationHashCode = Animator.StringToHash("isRunning");
        _groundStateHashCode = Animator.StringToHash("isGrounded");

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

    public void AnimateGrounded(bool isGrounded)
    {
        _animator.SetBool(_groundStateHashCode, isGrounded);
    }
    // public void RunAnimation(bool runAnimation)
    // {
    //     //_animator.SetBool
    // }

    public static void InvokeAnimation()
    {
        _instance.Animate?.Invoke();
    }
}