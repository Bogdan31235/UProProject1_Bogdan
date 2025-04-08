using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointLes14V2 : MonoBehaviour
{
    [SerializeField]
    CharacterSettings ordinary;
    [SerializeField]
    CharacterSettings magic;
    [SerializeField]
    CharacterSettings cowboy;

    [SerializeField]
    RuntimeAnimatorController controller;

    AbstractFactoryCharacter creator = new CreatorFireCharacter();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            creator = new CreatorFireCharacter();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            creator = new CreatorWaterCharacter();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            creator.CreateOrdinary(ordinary, controller);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            creator.CreateCowboy(cowboy, controller);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            creator.CreateMagic(magic, controller);
        }
    }
}


