using System;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;
    public Action<bool> OnPause;
    bool isPaused;

    private void Start()
    {
        player.GetInputActions().Gameplay.Pause.performed += ctx => Pause(true);
        player.GetInputActions().UI.Back.performed += ctx => Pause(false);
    }

    void Pause(bool value)
    {
        isPaused = value;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        OnPause?.Invoke(isPaused);

        if(isPaused)
        {
            player.GetInputActions().Gameplay.Disable();
        }
        else
        {
            player.GetInputActions().Gameplay.Enable();
            player.GetInputActions().UI.Back.performed -= ctx => Pause(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
