using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactoryCharacter
{
    public abstract void CreateOrdinary(CharacterSettings prefab, RuntimeAnimatorController controller);
    public abstract void CreateCowboy(CharacterSettings prefab, RuntimeAnimatorController controller);
    public abstract void CreateMagic(CharacterSettings prefab, RuntimeAnimatorController controller);

}
