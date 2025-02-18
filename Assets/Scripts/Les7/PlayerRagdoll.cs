using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : MonoBehaviour, IDamangable
{
    RagdollHandler ragdollHandler;
    Animator animator;
    RagdollMove move;

    public void TakeDamage(Vector3 force, Vector3 hitPoistion)
    {
        ragdollHandler.Hit(force, hitPoistion);
        EnableRagdoll();
    }

    private void EnableRagdoll()
    {
        animator.enabled = false;
        move.enabled = false;
        ragdollHandler.Enable();
    }

    void Start()
    {
        ragdollHandler = GetComponent<RagdollHandler>();
        animator = GetComponent<Animator>();
        move = GetComponent<RagdollMove>();

        ragdollHandler.Initilize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
