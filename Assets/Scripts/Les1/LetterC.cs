using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LetterC : MonoBehaviour,ILetter
{
    private Material mat;
    

    public void Click()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(mat.DOFade(0, 1f));
        seq.AppendInterval(2f);
        seq.Append(mat.DOFade(1, 1f));

        seq.Play();
    }

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        
    }
}
