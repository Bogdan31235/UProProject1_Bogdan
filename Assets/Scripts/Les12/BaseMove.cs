using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMove : IMoving
{
    [SerializeField]
    protected float speed;//скорость

    protected Transform moveTransform;//движение
    protected Animator anim;//анимация
    protected string nameClip;// клип в строке

    public BaseMove(float speed, Transform moveTransform, Animator anim, string nameClip)// базовые состояния
    {
        this.speed = speed;
        this.moveTransform = moveTransform;
        this.anim = anim;
        this.nameClip = nameClip;
    }

    public virtual void Move(float move)
    {
        moveTransform.parent.parent.Translate(0, 0, move * speed); //передвижение объекта
    }

    public void PlayClip()
    {
        if (anim != null)// существует ли объект
        {
            anim.Play(nameClip, -1, -1);// анимация воспроизводится
        }
    }
}
