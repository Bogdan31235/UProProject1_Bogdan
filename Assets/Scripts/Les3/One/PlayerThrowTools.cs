using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowTools : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            GetComponentInChildren<ITool>()?.Throw();
    }
}
