using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void FindAnimator()
    {
        animator = GetComponent<Animator>();

    }
    public void SetAvatar(Avatar avatar)
    {
        if(animator == null)
        {
            Debug.LogError("Animator not found");
                return;
        }

        animator.avatar = avatar;
    }
    public void SetController(RuntimeAnimatorController controller)
    {
        if(animator == null)
        {
            Debug.LogError("Animator not found");
            return;
        }
        animator.runtimeAnimatorController = controller;
    }
}
