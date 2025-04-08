using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointLes14W1 : MonoBehaviour
{
    [SerializeField]
    CharacterSettings ordinary;
    [SerializeField]
    CharacterSettings magic;
    [SerializeField]
    CharacterSettings cowboy;

    [SerializeField]
    RuntimeAnimatorController controller;
    CreatorCharacter creator = new CreatorMagic();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            creator = new CreatorOrdinary();
            creator.CreateCharacter(ordinary, controller);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            creator = new CreatorCowboy();
            creator.CreateCharacter(cowboy, controller);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            creator = new CreatorMagic();
            creator.CreateCharacter(magic, controller);
        }
    }
}
