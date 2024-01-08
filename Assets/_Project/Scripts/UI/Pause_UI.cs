using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_UI : Page_UI
{
    [SerializeField] GameController gameController;
    [SerializeField] Button exitGameBtn;

    private void Start()
    {
        gameController.OnPause += SetVisibility;
        exitGameBtn.onClick.AddListener(gameController.ExitGame);
    }
}
