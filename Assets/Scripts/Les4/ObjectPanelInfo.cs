using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectPanelInfo : MonoBehaviour
{
    [SerializeField]
    private Image imageObject;
    [SerializeField]
    private TMP_Text textObject;
    [SerializeField]
    private Sprite spriteObject;
    [SerializeField]
    private string nameObject;

    

    private void Awake()
    {
        imageObject.sprite = spriteObject;
        textObject.text = nameObject;
    }
    
}
