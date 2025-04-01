using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox3 : MonoBehaviour, IEnemyDamagable
{

    private void Awake()
    {
        GetComponent<RagdollHandler>().Initilize();
    }

    public void TakeDamage()
    {
        GetComponent<EnemyHPRagdoll>().HP = -1;
    }
}
