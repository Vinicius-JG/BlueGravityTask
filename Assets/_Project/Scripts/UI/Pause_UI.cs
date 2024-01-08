using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_UI : Page_UI
{
    [SerializeField] GameController gameController;
    [SerializeField] Button resumeBtn;
    [SerializeField] Button exitGameBtn;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;


    private void Start()
    {
        gameController.OnPause += SetVisibility;
        resumeBtn.onClick.AddListener(() => gameController.Pause(false));
        exitGameBtn.onClick.AddListener(gameController.ExitGame);

        sfxSlider.onValueChanged.AddListener(OnSFXSliderChange);
        musicSlider.onValueChanged.AddListener(OnMusicSliderChange);

        sfxSlider.value = PlayerPrefs.GetFloat("SFX_Volume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("Music_Volume", 0.5f);
    }

    void OnSFXSliderChange(float value)
    {
        AudioManager.Instance.ChangeSFXVolume(value);
    }

    void OnMusicSliderChange(float value)
    {
        AudioManager.Instance.ChangeMusicVolume(value);
    }
}
