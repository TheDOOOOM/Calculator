using Calculator._Scripts.SO;
using Services;
using TMPro;
using UnityEngine;

public class SetNumberFour : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private TextMeshProUGUI _textValue;

    private DisplayShowResult _displayResult;

    private void Start()
    {
        _displayResult = ServiceLocator.Instance.GetService<DisplayShowResult>();
        _textValue.text = $"{_levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig).TargetNumberFour}";
    }

    public void AddNumber()
    {
        _displayResult.SetNumber(
            _levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig).TargetNumberFour);
    }
}