using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeTools : MonoBehaviour
{
    [SerializeField]
    private Transform positon;

    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
            other.GetComponent<ITool>()?.Take(positon.localPosition, transform);
    }
}
