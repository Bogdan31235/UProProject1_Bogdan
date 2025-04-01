using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPRagdoll : EnemyHP
{
    public override int HP
    {
        set
        {
            hp += value;


            if (hp <= 0)
            {

                GetComponent<Animator>().enabled = false;
                GetComponent<RagdollHandler>().Enable();
                Destroy(gameObject, 3f); 
            }

        }
    }
}
