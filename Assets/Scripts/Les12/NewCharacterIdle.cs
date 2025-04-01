using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FSMControllerLes12;

public class NewCharacterIdle : CharacterIdle
{
    public override void Do()
    {
        float move = Input.GetAxis(nameV) * Time.deltaTime;

        if (move != 0)
            GetComponentInParent<FSMControllerLes12>().SwitchState(NewCharacterState.Move);
    }

}
