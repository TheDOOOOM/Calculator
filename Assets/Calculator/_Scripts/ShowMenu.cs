using Services;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    private DisplayCalculator _displayCalculator;
    private SoundService _soundService;

    private void Start()
    {
        _displayCalculator = ServiceLocator.Instance.GetService<DisplayCalculator>();
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void ShowMenuDisplay()
    {
        _displayCalculator.ShowMenu();
        _soundService.PlayClick();
    }
}