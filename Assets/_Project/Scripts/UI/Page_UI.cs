using UnityEngine;
using System.Collections;

public class Page_UI : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    bool isOn;

    private void Awake()
    {
        SetVisibility(false);
    }

    public void SetVisibility(bool value)
    {
        if (value != isOn)
            AudioManager.Instance.PlaySFX(value ? AudioManager.Instance.genericAudioClips[0] : AudioManager.Instance.genericAudioClips[1]);

        canvasGroup.alpha = value ? 1f : 0f;
        canvasGroup.blocksRaycasts = value;
        isOn = value;
    }

    public bool IsOn()
    {
        return isOn;
    }
}
