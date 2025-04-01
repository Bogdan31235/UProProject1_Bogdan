using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : BaseMove
{
    public WallMove(float speed, Transform moveTransform, Animator anim, string nameClip) : base(speed, moveTransform, anim, nameClip)
    {
    }
}
