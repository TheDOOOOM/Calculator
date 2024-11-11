using System.Collections;
using System.Collections.Generic;
using Calculator._Scripts.SO;
using Services;
using TMPro;
using UnityEngine;

public class AddValueOne : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private TextMeshProUGUI _text;

    private DisplayShowResult _displayShowResult;
    private int value;

    private void Awake()
    {
        _displayShowResult = ServiceLocator.Instance.GetService<DisplayShowResult>();
        var levelConfig = _levelsConfig.GetNumberLevel(_levelsConfig.ActiveNumberConfig);
        value = levelConfig.ValueOne;
        _text.text = $"+{value}";
    }

    public void AddValue()
    {
        _displayShowResult.AddValue(value);
    }
}