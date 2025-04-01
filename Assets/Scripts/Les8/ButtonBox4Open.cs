using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBox4Open : ButtonBoxOpen
{
    [SerializeField]
    private EnemyMoveRagdoll _enemyMoveRagdoll;
    public override void Click()
    {
        base.Click();
        _enemyMoveRagdoll.enabled = true;
    }
}
