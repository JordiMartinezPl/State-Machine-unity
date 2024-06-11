using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInput input;
    private PlayerMovement movement;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        animator.SetBool("walk", movement.checkIsMoving);
        animator.SetBool("sneak", input.sneak);
    }
}
