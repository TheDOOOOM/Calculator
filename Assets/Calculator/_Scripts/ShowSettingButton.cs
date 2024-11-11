using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class ShowSettingButton : MonoBehaviour
{
    private DisplayCalculator _displayCalculator;
    private SoundService _soundService;

    private void Start()
    {
        _displayCalculator = ServiceLocator.Instance.GetService<DisplayCalculator>();
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void SwitchSettings()
    {
        _displayCalculator.ShowSettings();
        _soundService.PlayClick();
    }
}