
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FSMController;

public class CharacterRun : State
{
    [SerializeField]
    private float _speedWallkin = 20;

    [SerializeField]
    private string nameH = "Horizontal";
    [SerializeField]
    private string nameV = "Vertical";

    public override void Do()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GetComponentInParent<FSMController>().SwitchState(CharacterState.Move);
        }

        float move = Input.GetAxis(nameV) * _speedWallkin * Time.deltaTime;

        transform.parent.parent.Translate(0, 0, move);
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Run Enter");
    }
}
