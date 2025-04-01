using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorBox4 : MonoBehaviour, IDoor
{
    [SerializeField]
    private float rotateY = 90;
    Sequence seq;

    public void Open()
    {
        seq = DOTween.Sequence();

        seq.Append(transform.DOLocalRotate(new Vector3(0, 0, rotateY), 2));
        seq.AppendInterval(5);
        seq.Append(transform.DOLocalRotate(new Vector3(0, 0, 0), 2));

        seq.Play();
    }
}
