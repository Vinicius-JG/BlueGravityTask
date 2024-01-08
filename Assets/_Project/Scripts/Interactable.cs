using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] GameObject interactionCanvas;
    public Action<Actor> OnInteract;

    public void Interact(Actor actor)
    {
        OnInteract?.Invoke(actor);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.genericAudioClips[0]);
    }

    public void SetInteractionCanvasVisibility(bool value)
    {
        interactionCanvas?.SetActive(value);
    }

}
