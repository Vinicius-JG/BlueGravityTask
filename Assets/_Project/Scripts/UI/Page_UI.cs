using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Purchasing.MiniJSON;

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

    public bool IsOn()
    {
        return isOn;
    }
}