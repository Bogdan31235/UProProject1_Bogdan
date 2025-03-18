using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FSMController;

public class CharacterIdle : State
{
    [SerializeField]
    protected string nameH = "Horizontal";
    [SerializeField]
    protected string nameV = "Vertical";

    public override void Do()
    {

        float move = Input.GetAxis(nameV) * Time.deltaTime;

        if (move != 0)
            GetComponentInParent<FSMController>().SwitchState(CharacterState.Move);
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idle Enter");
    }
}
