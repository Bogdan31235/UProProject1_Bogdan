using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Les10EntryPoint : MonoBehaviour
{

    [SerializeField]
    private BulletLes10 bullet;

    void Start()
    {
        ObjectsPool.Instance.AddObjects(bullet, 10);

    }
}
