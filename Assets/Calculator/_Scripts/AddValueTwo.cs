using Calculator._Scripts.SO;
using Services;
using TMPro;
using UnityEngine;

public class AddValueTwo : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private TextMeshProUGUI _text;

    private DisplayShowResult _displayShowResult;
    private SoundService _soundService;
    private int value;

    private void Awake()
    {
        _displayShowResult = ServiceLocator.Instance.GetService<DisplayShowResult>();
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
        var levelConfig = _levelsConfig.GetNumberLevel(_levelsConfig.ActiveNumberConfig);
        value = levelConfig.ValueTwo;
        _text.text = $"+{value}";
    }

    public void AddValue()
    {
        _displayShowResult.AddValue(value);
    }
}