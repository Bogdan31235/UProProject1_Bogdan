using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField]
    private CreatePlayer player;
    [SerializeField]
    private FindCharacter[] enemy;

    private void Awake()
    {
        player.Init();
        foreach (var en in enemy)
            en.Init();
    }


}
