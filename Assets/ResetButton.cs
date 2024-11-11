using System;
using System.Collections;
using System.Collections.Generic;
using Calculator._Scripts.SO;
using Services;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levels;

    private SoundService _soundService;

    private void Start()
    {
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void ResetProgress()
    {
        _levels.Reset();
        _soundService.PlayClick();
    }
}