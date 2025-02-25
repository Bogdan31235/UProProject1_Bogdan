using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door1 : MonoBehaviour, IDoor
{
    public void Open()
    {
        Sequence seq = DOTween.Sequence();
        
        seq.AppendInterval(2f);

    }
}
