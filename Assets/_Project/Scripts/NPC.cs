using Animancer.Examples.AnimatorControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class NPC : MonoBehaviour
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