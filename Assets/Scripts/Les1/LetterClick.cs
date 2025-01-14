using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterClick : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out RaycastHit hit))
                if(hit.collider.GetComponent<ILetter>()!=null)
                    hit.collider.GetComponent<ILetter>().Click();
        }
    }
}
