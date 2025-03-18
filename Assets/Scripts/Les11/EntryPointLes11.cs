using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointLes11 : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<FSMController>()?.Init();
    }

    
}
