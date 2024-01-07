using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Page_UI : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    bool isOn;
    bool fading;

    public void SetVisibility(bool value)
    {
        if (fading)
            return;

        canvasGroup.alpha = value ? 0f : 1f;
        canvasGroup.blocksRaycasts = !value;
        fading = true;
        canvasGroup.DOFade(value ? 1f : 0f, 0.25f).OnComplete(() => {
            canvasGroup.blocksRaycasts = value;
            isOn = value;
            fading = false;
        });
    }

    public bool Ison()
    {
        return isOn;
    }
}
