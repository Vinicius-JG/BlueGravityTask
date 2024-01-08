using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] GameObject interactionCanvas;
    public Action<Actor> OnInteract;

    public void Interact(Actor actor)
    {
        OnInteract?.Invoke(actor);
    }

    public void SetInteractionCanvasVisibility(bool value)
    {
        interactionCanvas?.SetActive(value);
    }

}
