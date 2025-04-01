using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimButtonObjectPanel : MonoBehaviour
{

    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(GetComponent<RectTransform>().DOScale(new Vector3(0.8f, 0.8f, 0.8f), 1f));
        sequence.Append(GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 1f));

        sequence.SetLoops(-1,LoopType.Restart);
    }

    
}
