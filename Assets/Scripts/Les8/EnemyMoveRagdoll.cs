using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRagdoll : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.1f;
    private Transform _target;

    private void OnEnable()
    {
        _target = FindObjectOfType<PlayerLes3>().transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 dir = (transform.position - _target.position).normalized;
            dir.y = 0;

            transform.Translate(dir * _speed * Time.deltaTime);
        }
    }
}
