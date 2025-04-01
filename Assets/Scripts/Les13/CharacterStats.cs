using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats 
{
    public int HP = 0;
    public int damage = 0;
    public int level = 0;

    public CharacterStats(int hP, int damage, int level)
    {
        HP = hP;
        this.damage = damage;
        this.level = level;
    }
}
