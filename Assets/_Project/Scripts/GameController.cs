using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Action<bool> OnPause;
    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    void Pause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        OnPause?.Invoke(isPaused);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
