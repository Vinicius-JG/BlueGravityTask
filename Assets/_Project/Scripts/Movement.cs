using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Start()
    {
        GetComponent<Player>().GetInputActions().Gameplay.Move.performed += OnMove;
        GetComponent<Player>().GetInputActions().Gameplay.Move.canceled += CancelMove;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleAnimation();
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

    public Vector2 GetLookDir()
    {
        return lookDir;
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        input = ctx.ReadValue<Vector2>();
    }

    void CancelMove(InputAction.CallbackContext ctx)
    {
        input = Vector2.zero;
    }
}
