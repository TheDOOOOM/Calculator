using Calculator._Scripts.SO;
using Services;
using TMPro;
using UnityEngine;

public class SetNumberFree : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private TextMeshProUGUI _textValue;

    private DisplayShowResult _displayResult;

    private void Start()
    {
        _displayResult = ServiceLocator.Instance.GetService<DisplayShowResult>();
        _textValue.text = $"{_levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig).TargetNumberOFree}";
    }

    public void AddNumber()
    {
        _displayResult.SetNumber(
            _levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig).TargetNumberOFree);
    }
}