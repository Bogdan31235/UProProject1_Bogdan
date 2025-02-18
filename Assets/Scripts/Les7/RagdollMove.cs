using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float speedTurn = 10;
    [SerializeField]
    private string nameH;
    [SerializeField]
    private string nameV;
    [SerializeField]
    private KeyCode keyAttack;

    private bool isAttack = false;

    Animator animator;
    bool isMove = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DisMove()
    {
        isMove = false;
    }

    private void Update()
    {
        if (isMove)
        {
            float move = Input.GetAxis(nameV) * speed * Time.deltaTime;
            float turn = Input.GetAxis(nameH) * speedTurn * Time.deltaTime;

            if (move != 0 || turn != 0) animator.SetBool("isMove", true);
            else animator.SetBool("isMove", false);

            transform.Translate(0, 0, move);
            transform.Rotate(0, turn, 0);

            if (Input.GetKeyDown(keyAttack))
                animator.SetTrigger("isAttack");
        }
    }
}
