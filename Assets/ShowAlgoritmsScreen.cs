using Services;
using UnityEngine;

public class ShowAlgoritmsScreen : MonoBehaviour
{
    private DisplayCalculator _displayCalculator;
    private SoundService _soundService;

    private void Start()
    {
        _displayCalculator = ServiceLocator.Instance.GetService<DisplayCalculator>();
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void ShowScreen()
    {
        _displayCalculator.ShowGameAritmeticsScreen();
        _soundService.PlayClick();
    }
}