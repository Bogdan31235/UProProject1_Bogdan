using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorWaterCharacter : AbstractFactoryCharacter
{
    ICharacterBuilder character = new BuilderCharacter();

    public override void CreateCowboy(CharacterSettings prefab, RuntimeAnimatorController controller)
    {
        CharacterSettings idle = character
                                    .Reset()
                                    .SetPrefabs(prefab)
                                    .SetName("Cowboy")
                                    .SetStats(new CharacterStats(10, 5, 3))
                                    .SetAvatar(null)
                                    .SetController(controller)
                                    .Build();


        foreach (var mat in idle.GetComponentsInChildren<Renderer>())
        {
            Material material = mat.material;
            material.color = Color.blue;

            mat.material = material;
        }

    }

    public override void CreateMagic(CharacterSettings prefab, RuntimeAnimatorController controller)
    {
        CharacterSettings idle = character
                                    .Reset()
                                    .SetPrefabs(prefab)
                                    .SetName("Magic")
                                    .SetStats(new CharacterStats(1, 10, 5))
                                    .SetAvatar(null)
                                    .SetController(controller)
                                    .Build();

        foreach (var mat in idle.GetComponentsInChildren<Renderer>())
        {
            Material material = mat.material;
            material.color = Color.blue;

            mat.material = material;
        }
    }

    public override void CreateOrdinary(CharacterSettings prefab, RuntimeAnimatorController controller)
    {
        CharacterSettings idle = character
                                    .Reset()
                                    .SetPrefabs(prefab)
                                    .SetName("Ordinary")
                                    .SetStats(new CharacterStats(15, 1, 2))
                                    .SetAvatar(null)
                                    .SetController(controller)
                                    .Build();

        foreach (var mat in idle.GetComponentsInChildren<Renderer>())
        {
            Material material = mat.material;
            material.color = Color.blue;

            mat.material = material;
        }
    }
}


