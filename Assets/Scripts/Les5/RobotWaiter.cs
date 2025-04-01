using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWaiter : MonoBehaviour, IRobots,IWaiter
{
    [SerializeField]
    protected GameObject _coffe;
    public virtual void Bring()
    {
        Debug.Log("Вот ваш кофе!");
        Instantiate(_coffe,transform.position+ new Vector3(0f,1f,-1f), Quaternion.identity);
    }

    public void Greeting()
    {
        Debug.Log("Привет! Я персональный официант!");
    }

    public virtual void Use()
    {
        Debug.Log("Я могу принести вам кофе!");
    }
}
