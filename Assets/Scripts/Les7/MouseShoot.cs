using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShoot : MonoBehaviour
{
    [SerializeField]
    private float forceShoot = 16;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.GetComponentInParent<IDamangable>() != null)
            {
                Vector3 direction = (hit.point - Camera.main.transform.position).normalized;
                direction.y = 0;

                hit.collider.GetComponentInParent<IDamangable>().TakeDamage(forceShoot*direction, hit.point);
            }
        }
    }
}
