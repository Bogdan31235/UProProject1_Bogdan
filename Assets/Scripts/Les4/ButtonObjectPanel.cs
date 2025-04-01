using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObjectPanel : ObjectPanelInfo
{
    [SerializeField]
    private Button buttonLevelUp;
    void Start()
    {
        buttonLevelUp.onClick.AddListener(() =>
        {
            Debug.Log("Weapon Level UP");
        });
    }

 
}
