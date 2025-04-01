using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    List<Rigidbody> rbs;

    public void Initilize()
    {
        rbs = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        Disable();
    }

    public void Hit(Vector3 force, Vector3 hitPosition)
    {
        Rigidbody rb = rbs.OrderBy(rb => Vector3.Distance(rb.position, hitPosition)).First();

        rb.AddForceAtPosition(force, hitPosition, ForceMode.Impulse);
    }

    public void Enable()
    {
        foreach (Rigidbody rb in rbs)
            rb.isKinematic = false;
    }

    public void Disable()
    {
        foreach (Rigidbody rb in rbs)
            if(!rb.GetComponent<Sword>())
                rb.isKinematic = true;
    }
}
