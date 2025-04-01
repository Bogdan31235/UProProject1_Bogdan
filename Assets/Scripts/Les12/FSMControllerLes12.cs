using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMControllerLes12 : MonoBehaviour
{
    [SerializeField]
    private State _idle;
    [SerializeField]
    private State _move;

    private LevelStateMachine _levelStateMachine = new LevelStateMachine();

    public void Init()
    {
        _levelStateMachine.AddState(_idle);
        _levelStateMachine.AddState(_move);

        _levelStateMachine.SetState(_idle);
    }

    public void SwitchState(NewCharacterState state)
    {
        switch (state)
        {
            case NewCharacterState.Idle:
                _levelStateMachine.SetState(_idle);
                break;
            case NewCharacterState.Move:
                _levelStateMachine.SetState(_move);
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

    public enum NewCharacterState
    {
        Idle,
        Move
    }
}
