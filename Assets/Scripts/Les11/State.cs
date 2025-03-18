using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour, ILevelState
{
    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    protected string _clip;

    public virtual void Do()
    {
    }

    public virtual void Enter()
    {
        if (_animator != null)
        {
            _animator.Play(_clip, -1, -1);
        }
    }

    public virtual void Exit()
    {
    }

    public virtual void FixedDo()
    {
    }
}


