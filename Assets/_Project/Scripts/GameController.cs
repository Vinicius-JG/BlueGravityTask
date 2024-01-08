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
        player.GetInputActions().Gameplay.Pause.performed += ctx => Pause(!isPaused);
    }

    public void Pause(bool value)
    {
        isPaused = value;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        OnPause?.Invoke(isPaused);

        if(isPaused)
        {
            player.GetInputActions().Gameplay.Disable();
            player.GetInputActions().Gameplay.Pause.Enable();
        }
        else
        {
            player.GetInputActions().Gameplay.Enable();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
