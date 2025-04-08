using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorOrdinary : CreatorCharacter
{
    public override void CreateCharacter(CharacterSettings prefab, RuntimeAnimatorController controller)
    {
        ICharacterBuilder character = new BuilderCharacter();
        CharacterSettings idle = character
                           .Reset()
                           .SetPrefabs(prefab)
                           .SetName("Odrinary")
                           .SetStats(new CharacterStats(10, 3, 1))
                           .SetAvatar(null)
                           .SetController(controller)
                           .Build();
    }
}
