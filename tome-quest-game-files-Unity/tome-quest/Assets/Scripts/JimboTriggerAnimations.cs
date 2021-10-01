using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimboTriggerAnimations : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            animator.Play("Base Layer.Figure|AttackAction", 0, 0);
            print("Attack");
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            animator.Play("Base Layer.Figure|DamagedAction", 0, 0);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            animator.Play("Base Layer.Figure|BlockAction", 0, 0);
        }
    }
}
