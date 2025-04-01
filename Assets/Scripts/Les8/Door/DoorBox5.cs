using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBox5 : MonoBehaviour, IDoor
{
    Sequence seq;

    public void Open()
    {
        seq = DOTween.Sequence();

        seq.Append(transform.DOScale(new Vector3(0f, 0f, 0f), 2));
        seq.AppendInterval(5);
        seq.Append(transform.DOScale(new Vector3(8f, 4f, 0.1f), 2));

        seq.Play();
    }
}
