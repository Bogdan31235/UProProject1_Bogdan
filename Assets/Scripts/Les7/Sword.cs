using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private Transform parent;

    private void Start()
    {
        foreach (Collider col in parent.GetComponentsInChildren<Collider>())
            Physics.IgnoreCollision(GetComponent<Collider>(), col);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponentInParent<IDamangable>() != null)
        {

            Vector3 direction = (collision.contacts[0].point - Camera.main.transform.position).normalized;
            direction.y = 0;

            collision.collider.GetComponentInParent<IDamangable>().TakeDamage(direction, collision.contacts[0].point);
        }
    }
}
