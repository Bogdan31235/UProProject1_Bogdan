using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{
    [SerializeField]
    private State _idle;
    [SerializeField]
    private State _move;
    [SerializeField]
    private State _run;

    private LevelStateMachine _levelStateMachine = new LevelStateMachine();

    public void Init()
    {
        _levelStateMachine.AddState(_idle);
        _levelStateMachine.AddState(_move);
        _levelStateMachine.AddState(_run);

        _levelStateMachine.SetState(_idle);
    }

    public void SwitchState(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Idle:
                _levelStateMachine.SetState(_idle);
                break;
            case CharacterState.Move:
                _levelStateMachine.SetState(_move);
                break;
            case CharacterState.Run:
                _levelStateMachine.SetState(_run);
                break;
        }
    }

    private void Update()
    {
        _levelStateMachine.Update();
    }

    private void FixedUpdate()
    {
        _levelStateMachine.Fixed();
    }

    public enum CharacterState
    {
        Idle,
        Move,
        Run
    }
}


