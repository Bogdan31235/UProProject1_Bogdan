using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColPlayerCoin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<coin>()) {
            ManagerCoin.Instance.Coin = 1;
            Destroy(collision.gameObject.gameObject);
        }
    }
}
