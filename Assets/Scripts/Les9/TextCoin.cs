using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextCoin : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TMP_Text>().text = ManagerCoin.Instance.Coin.ToString();
    }
}
