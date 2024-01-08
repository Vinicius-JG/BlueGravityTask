using UnityEngine;
using DG.Tweening;

public class Page_UI : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    bool isOn;
    bool fading;

    private void Awake()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public void Fade(bool value)
    {
        if (fading)
            return;

        SetVisibility(!value);

        fading = true;
        canvasGroup.DOFade(value ? 1f : 0f, 0.25f).OnComplete(() => {
            SetVisibility(value);
            fading = false;
        }).SetUpdate(true).OnKill(() => fading = false);
    }

    public void SetVisibility(bool value)
    {
        canvasGroup.alpha = value ? 1f : 0f;
        canvasGroup.blocksRaycasts = value;
        isOn = value;
    }

    public bool IsOn()
    {
        return isOn;
    }
}
