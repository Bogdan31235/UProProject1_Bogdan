using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] CreatePlayer createPlayer;
    [SerializeField] FindCharacter[] findCharacter;

    private void Awake()
    {
        createPlayer.Init();
        foreach (var enemy in findCharacter) enemy.Init();
    }
}
