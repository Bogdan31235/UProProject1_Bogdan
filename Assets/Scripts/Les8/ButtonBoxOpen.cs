using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBoxOpen : MonoBehaviour, IButtonOpenBox
{
    [SerializeField]
    private GameObject _box;

    public virtual void Click()
    {
        foreach(IDoor door in _box.GetComponentsInChildren<IDoor>())
            door.Open();
    }
}
