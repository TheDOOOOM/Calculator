using Services;
using UnityEngine;

public class ShowGameMenu : MonoBehaviour
{
    private DisplayCalculator _displayCalucalator;
    private SoundService _soundService;

    private void Start()
    {
        _displayCalucalator = ServiceLocator.Instance.GetService<DisplayCalculator>();
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void ShowGame()
    {
        _displayCalucalator.ShowGameMenu();
        _soundService.PlayClick();
    }
}