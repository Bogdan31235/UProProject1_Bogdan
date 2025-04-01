using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderCharacter : ICharacterBuilder
{
    private CharacterSettings prefabs;
    private string prefabName;
    private CharacterStats prefabCharacterStats;
    private Avatar avatar;
    private RuntimeAnimatorController controller;

    public ICharacterBuilder SetAvatar(Avatar avatar)
    {
        this.avatar = avatar;

        return this;
    }
    public ICharacterBuilder SetController(RuntimeAnimatorController controller)
    {
        this.controller = controller;

        return this;
    }

    public ICharacterBuilder SetStats(CharacterStats prefabCharacterStats)
    {
        this.prefabCharacterStats = prefabCharacterStats;

        return this;
    }

    public ICharacterBuilder SetName(string name)
    {
        this.prefabName = name;

        return this;
    }

    public ICharacterBuilder SetPrefabs(CharacterSettings prefabs)
    {
        this.prefabs = prefabs;
        return this;
    }

    public CharacterSettings Build()
    {
        CharacterSettings characterSettings = Object.Instantiate(prefabs);

        characterSettings.SetName(prefabName);
        characterSettings.SetStats(prefabCharacterStats);

        CharacterAnim characterAnim = characterSettings.gameObject.AddComponent<CharacterAnim>();

        characterAnim.FindAnimator();
        characterAnim.SetAvatar(avatar);
        characterAnim.SetController(controller);
        Debug.Log(characterSettings.ToString());

        return characterSettings;
    }

    public ICharacterBuilder Reset()
    {
        prefabs = null;
        prefabCharacterStats = null;
        prefabName = null;
        avatar = null;
        controller = null;

        return this;
    }
}



