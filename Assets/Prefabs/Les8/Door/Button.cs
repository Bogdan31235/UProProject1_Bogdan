using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour, IButtonOpenDoor
{
    public void Click()
    {
        FindObjectOfType<ButtonClick>()?.transform.GetChild(0).gameObject.SetActive(true);
    }
}

