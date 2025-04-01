using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBox3 : MonoBehaviour, IDoor
{
    Sequence seq;
    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void Open()
    {
        seq = DOTween.Sequence();


        seq.Append(material.DOFade(0, 2));
        seq.AppendInterval(5);
        seq.Append(material.DOFade(1, 2));

        seq.Play();

        StartCoroutine(SwitchActiveCollider());
    }

    private void ActiveCollider(bool active)
    {
        GetComponent<Collider>().enabled = active;
    }

    IEnumerator SwitchActiveCollider()
    {

        ActiveCollider(false);

        yield return new WaitForSeconds(7);

        ActiveCollider(true);
    }
}
