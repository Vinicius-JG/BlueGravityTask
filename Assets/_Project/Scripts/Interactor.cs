using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    Movement movement;
    Interactable interactable;

    private void Awake()
    {
        movement = transform.root.GetComponent<Movement>();
    }

    private void Update()
    {
        transform.localPosition = movement.GetLookDir();

        if (Input.GetKeyDown(KeyCode.E))
            interactable?.Interact(transform.root.GetComponent<Actor>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactable = collision.GetComponent<Interactable>();
            interactable.SetInteractionCanvasVisibility(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactable.SetInteractionCanvasVisibility(false);
            interactable = null;
        }
    }
}
