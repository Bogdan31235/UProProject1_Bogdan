using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCharacter : MonoBehaviour
{
    GameObject character;

    public void Init()
    {
        character= FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        if (character != null)
        {
            transform.LookAt(character.transform.position);
        }
    }
}
