using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsOnRobots : MonoBehaviour
{
   
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            if (hit.collider.GetComponent<IRobots>() != null)
            {

                if (Input.GetKeyDown(KeyCode.Alpha1))
                    hit.collider.GetComponent<IRobots>().Greeting();

                if (Input.GetKeyDown(KeyCode.Alpha2))
                    hit.collider.GetComponent<IRobots>().Use();
            }

            if (hit.collider.GetComponent<IWaiter>() != null)
            {
                if (Input.GetKeyDown(KeyCode.Alpha3))
                    hit.collider.GetComponent<IWaiter>().Bring();
            }

            
        }
    }
}
