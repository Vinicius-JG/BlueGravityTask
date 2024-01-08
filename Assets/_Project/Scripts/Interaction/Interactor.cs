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
        
        transform.root.GetComponent<Player>().GetInputActions().Gameplay.Interact.performed += ctx => interactable?.Interact(transform.root.GetComponent<Actor>());
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
