using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LetterR : MonoBehaviour, ILetter
{
    private Material mat;
    private Color currentColor;

    public void Click()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(mat.DOColor(Random.ColorHSV(), 1f));
        seq.AppendInterval(2f);
        seq.Append(mat.DOColor(currentColor, 1f));

        seq.Play();
    }

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        currentColor = mat.color;
    }

}
