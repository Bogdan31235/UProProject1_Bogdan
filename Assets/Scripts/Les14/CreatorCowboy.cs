using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorCowboy : CreatorCharacter
{
    public override void CreateCharacter(CharacterSettings prefab, RuntimeAnimatorController controller)
    {
        ICharacterBuilder character = new BuilderCharacter();
        CharacterSettings idle1 = character
                                    .Reset()
                                    .SetPrefabs(prefab)
                                    .SetName("Cowboy")
                                    .SetStats(new CharacterStats(5, 10, 3))
                                    .SetAvatar(null)
                                    .SetController(controller)
                                    .Build();
    }
}
