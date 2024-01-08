using System.Collections.Generic;
using UnityEngine;

public class NPC : Actor
{
    [SerializeField] List<Animator> animators;
    [SerializeField] Vector2 lookDir;

    private void Awake()
    {
        HandleAnimation();
    }

    void HandleAnimation()
    {
        foreach (Animator animator in animators)
        {
            if (!animator.isActiveAndEnabled)
                continue;

            animator.SetFloat("MoveX", lookDir.x);
            animator.SetFloat("MoveY", lookDir.y);

            animator.SetBool("IsMoving", false);
        }
    }
}
