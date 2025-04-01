using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCoin : Singleton<ManagerCoin>
{
    private int coin;
    public int Coin
    {
        get => coin;
        set => coin += value;
    }
  
}
