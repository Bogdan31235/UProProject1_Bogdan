using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowTools : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            GetComponentInChildren<ITool>()?.Throw();
    }
}
