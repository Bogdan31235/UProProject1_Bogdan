using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootEnemy : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                hit.collider.GetComponentInParent<IEnemySwitchColor>()?.SwitchColor();
                hit.collider.GetComponentInParent<IEnemyDamagable>()?.TakeDamage();
            }
        }
    }
}
