using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] List<Animator> animators;

    Vector2 input;
    Vector2 lookDir;
    Rigidbody2D rb;
    bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleAnimation();
    }

    private void HandleInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    private void HandleMovement()
    {
        //rb.velocity = input.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + input.normalized * speed * Time.fixedDeltaTime);
        isMoving = input != Vector2.zero;
    }

    private void HandleAnimation()
    {
        if (isMoving)
            lookDir = input;

        foreach (Animator animator in animators)
        {
            if (!animator.isActiveAndEnabled)
                continue;

            animator.SetFloat("MoveX", lookDir.x);
            animator.SetFloat("MoveY", lookDir.y);

            animator.SetBool("IsMoving", isMoving);
        }
    }
}
