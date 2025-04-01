using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorBox1 : MonoBehaviour, IDoor
{
    Sequence seq;

    public void Open()
    {
        seq = DOTween.Sequence();

        seq.Append(transform.DOMoveY(6, 2));
        seq.AppendInterval(5);
        seq.Append(transform.DOMoveY(2, 2));

        seq.Play();
    }
}
