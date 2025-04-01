using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    protected int hp = 3;

    public virtual int HP
    {
        set 
        {
            hp += value; 

            if (hp <= 0 )
                Destroy(gameObject);
        }
    }
}
