using Services;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private DisplayCalculator _displayCalculator;
    private SoundService _soundService;

    private void Start()
    {
        _displayCalculator = ServiceLocator.Instance.GetService<DisplayCalculator>();
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void ShowGameScreenNumber()
    {
        _displayCalculator.ShowGameNumberScreen();
        _soundService.PlayClick();
    }
}