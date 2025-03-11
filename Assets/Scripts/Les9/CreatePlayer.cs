using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject character;


    public void Init()
    {
        Instantiate(character);
    }
}
