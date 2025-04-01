using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemy : MonoBehaviour, IRobotMove
{
    Rigidbody rb;
    private float dist = 3;
    private int cof = -1;

    public void Move()
    {
        Debug.Log($"Дистанция для Аватара: {dist}, Cof{cof}");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
