using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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

    private int _parameterCount;

    //Array int for hashes code from animations strings
    private int[] _animationParameterHashes;

    public int[] AnimationParameterHashes { get { return _animationParameterHashes; } set { _animationParameterHashes = value; } }


    //Events for Animations

    public delegate void AnimationLoader();

    public event AnimationLoader Animate;

    private void Awake()
    {
        _instance = this;

        // StringToHash helps optimize animations a bit

        // _walkAnimationHashCode = Animator.StringToHash("isMoving");
        // _runAnimationHashCode = Animator.StringToHash("isRunning");
        // _groundStateHashCode = Animator.StringToHash("isGrounded");
        GetAnimationsParameters();

        //animatorController.AddParameter("TestParameter", AnimatorControllerParameterType.Bool);

        // for (int i = 0; i < _animator.parameters.Length; i++)
        // {
        //     Debug.Log("Hash ID almacenado: " + _animationParameterHashes[i]);
        // }
    }

    private void GetAnimationsParameters()
    {
        _parameterCount = _animator.parameterCount;
        _animationParameterHashes = new int[_parameterCount];

        for (int i = 0; i < _parameterCount; i++)
        {
            //Debug.Log(_animator.parameters[i].name);
            _animationParameterHashes[i] = _animator.parameters[i].nameHash;
            //Debug.Log("Hash ID generado: " + _animationParameterHashes[i]);
        }
    }

    // public void AnimateWalk(bool isMoving)
    // {
    //     _animator.SetBool(_walkAnimationHashCode, isMoving);
    // }

    // public void AnimateRun(bool isRunning)
    // {
    //     _animator.SetBool(_runAnimationHashCode, isRunning);
    // }

    // public void AnimateGrounded(bool isGrounded)
    // {
    //     _animator.SetBool(_groundStateHashCode, isGrounded);
    // }

    public void RunAnimation(int animationParameterHash)
    {
        _animator.SetTrigger(animationParameterHash);
    }

    public void RunAnimation(int animationParameterHash, bool isRunAnimation)
    {
        _animator.SetBool(animationParameterHash, isRunAnimation);
    }

    public void RunAnimation(int animationParameterHash, float floatNumber)
    {
        _animator.SetFloat(animationParameterHash, floatNumber);
    }

    public static void InvokeAnimation()
    {
        _instance.Animate?.Invoke();
    }
}