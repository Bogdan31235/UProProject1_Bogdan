using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComarEnemy : MonoBehaviour,IRobotMove
{
    Rigidbody rb;
    public float dist = 0;
    private int cof = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        Debug.Log($"Дистанция комара :{dist},Cof{cof}");
    }
}
