
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FSMController;

public class CharacterMove : State
{
    [SerializeField]
    protected float _speedWallkin = 10;

    [SerializeField]
    protected string nameH = "Horizontal";
    [SerializeField]
    protected string nameV = "Vertical";

    public override void Do()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponentInParent<FSMController>().SwitchState(CharacterState.Run);
        }

        float move = Input.GetAxis(nameV) * _speedWallkin * Time.deltaTime;

        if (move == 0)
            GetComponentInParent<FSMController>().SwitchState(CharacterState.Idle);

        transform.parent.parent.Translate(0, 0, move);
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Move Enter");
    }
}