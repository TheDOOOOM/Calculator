using Services;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private DisplayCalculator _displayCalculator;

    private void Start()
    {
        _displayCalculator = ServiceLocator.Instance.GetService<DisplayCalculator>();
    }

    public void ShowExitScreen()
    {
        _displayCalculator.ShowExitScreen();
    }
}