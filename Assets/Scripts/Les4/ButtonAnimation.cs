using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ButtonAnimation : MonoBehaviour
{
    public RectTransform buttonTransform;

    private void Start()
    {

        gameObject.transform.DOScale(0.85f, 0.6f).SetLoops(-1, LoopType.Yoyo);
    }



}
