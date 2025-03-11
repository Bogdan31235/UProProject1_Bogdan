using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObjectPanel : ObjectPanelInfo
{
    [SerializeField]
    private Button buttonLevelUp;

    private void Start()
    {
     /*   buttonLevelUp.onClick.AddListener(() =>
        {
            Debug.Log("Weapon Level Up");
        });*/
    }
}
