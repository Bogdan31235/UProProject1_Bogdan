using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IButtonOpenDoor
{
    public void Click()
    {
        FindObjectOfType<Button>()?.transform.GetChild(0).gameObject.SetActive(true);
    }
}

