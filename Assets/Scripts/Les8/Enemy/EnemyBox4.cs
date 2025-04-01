using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox4 : MonoBehaviour, IEnemyDamagable, IEnemySwitchColor
{

    Sequence seq;
    Material material;
    Color _currentColor;

    private void Awake()
    {
        GetComponent<RagdollHandler>().Initilize();
    }

    private void Start()
    {
        material = GetComponentInChildren<Renderer>().material;
        _currentColor = material.color;
    }

    public void SwitchColor()
    {
        seq = DOTween.Sequence();

        seq.Append(material.DOColor(Color.red, 2));
        seq.AppendInterval(1);
        seq.Append(material.DOColor(_currentColor, 2));

        seq.Play();

    }

    public void TakeDamage()
    {
        GetComponent<EnemyHPRagdoll>().HP = -1;
    }
}
