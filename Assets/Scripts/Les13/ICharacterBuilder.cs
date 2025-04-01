using UnityEngine;

public interface ICharacterBuilder
{
    ICharacterBuilder SetPrefabs(CharacterSettings prefabs);
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetStats(CharacterStats stats);
    ICharacterBuilder SetAvatar(Avatar avatar);
    ICharacterBuilder SetController(RuntimeAnimatorController controller);
    CharacterSettings Build();
    ICharacterBuilder Reset();
}


