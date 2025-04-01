using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickB : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                if (hit.collider.GetComponent<IButtonPortal>() != null)
                    hit.collider.GetComponent<IButtonPortal>().ClickButton();
        }
    }
}
