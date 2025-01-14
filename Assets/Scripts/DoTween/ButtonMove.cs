using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonMove : MonoBehaviour
{
    [SerializeField]
    private float time = 2f;
    void Start()
    {
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(0,0), time).SetEase(Ease.Linear);
    }
}
