using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLes10 : MonoBehaviour
{
        private void OnEnable()
        {
            Invoke("DestroyBullet", 2f);
        }

        private void DestroyBullet()
        {
            ObjectsPool.Instance.ReturnObject(this);
        }
}
