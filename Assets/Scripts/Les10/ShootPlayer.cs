using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{

    [SerializeField]
    private BulletLes10 bullet;

    private bool isShoot = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && isShoot)
        {
            isShoot = false;
            GameObject obj = ObjectsPool.Instance.GetObject<BulletLes10>(bullet);

            obj.transform.localRotation = transform.localRotation;
            obj.transform.position = transform.position;

            obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * 100);

            Invoke("ActiveShoot", 0.1f);
        }
    }

    private void ActiveShoot()
    {
        isShoot = true;
    }

}
