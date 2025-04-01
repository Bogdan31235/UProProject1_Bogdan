using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Brick : MonoBehaviour, IBuildBlock
{
    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    public void ColorReset()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(rend.material.DOColor(Random.ColorHSV(), 1f));

        sequence.Play();
    }
    public void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
