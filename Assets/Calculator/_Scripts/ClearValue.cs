using Services;
using UnityEngine;

public class ClearValue : MonoBehaviour
{
    private DisplayShowResult _displayShowResult;

    private void Start()
    {
        _displayShowResult = ServiceLocator.Instance.GetService<DisplayShowResult>();
    }

    public void Clear()
    {
        _displayShowResult.ClearScreen();
        _displayShowResult.Reset();
    }
}