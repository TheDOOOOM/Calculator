using System;
using System.Collections.Generic;
using System.Linq;
using Calculator._Scripts.SO;
using Services;
using UnityEngine;

public class DisplayShowResult : MonoBehaviour, IService
{
    [SerializeField] private CharConfig[] _numbers;
    [SerializeField] private Transform _resultDisplay;
    [SerializeField] private List<GameObject> _zero;
    [SerializeField] private LevelsConfig _levelsConfig;

    private TargetValue _targetValue;
    private List<GameObject> _imagesHeader = new();
    private List<GameObject> _instanceZeroItems = new();
    private List<GameObject> _numbersInstance = new();

    private ResultValidator _resultValidator;
    private AlgoritmValidator _algoritmValidator;
    private SoundService _soundService;
    private string _activeString;

    public void ShowHeader(ICellsConfig config)
    {
        ClearScreen();
        var header = config.GetHeader();
        for (int i = 0; i < header.Count; i++)
        {
            var instanceItem = Instantiate(header[i], transform);
            _imagesHeader.Add(instanceItem);
        }
    }

    public void ActiveLevel()
    {
        _resultValidator = new ResultValidator(
            _levelsConfig.GetNumberLevel(_levelsConfig.ActiveNumberConfig).TargetNumber,
            _levelsConfig);
        _targetValue = ServiceLocator.Instance.GetService<TargetValue>();
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
        _targetValue.SetTargetValue(_levelsConfig.GetNumberLevel(_levelsConfig.ActiveNumberConfig).Steps,
            _levelsConfig.GetNumberLevel(_levelsConfig.ActiveNumberConfig).TargetNumber);
    }

    public void AddValue(int value)
    {
        if (_resultValidator.AddValue(value))
            ShowNumber(_resultValidator.Value);
        _soundService.PlayClick();
    }

    public void ShowNumber(int number)
    {
        ClearScreen();
        var chars = number.ToString();
        if (chars.Length > 6)
            return;
        InstanceZero(chars.Length);
        for (int i = 0; i < chars.Length; i++)
        {
            var matchingNumber = _numbers.FirstOrDefault(num => num.CharElement == chars[i]);
            InstanceNumber(matchingNumber.Sprite);
        }
    }

    public void SetAlgoritm(string algoritm)
    {
        _activeString = algoritm;
        _algoritmValidator = new AlgoritmValidator(_levelsConfig, this);
        _soundService = ServiceLocator.Instance.GetService<SoundService>();
        ShowText(algoritm);
    }

    private void UpdateCharacterInString(int value)
    {
        int index = _activeString.IndexOf('_');
        var charResult = (char)('0' + value);
        _activeString = _activeString.Substring(0, index) + value + _activeString.Substring(index + 1);
        Debug.Log(_activeString);
        ShowText(_activeString);
    }

    public void SetNumber(int value)
    {
        _soundService.PlayClick();
        UpdateActiveString(value);
    }

    public void ShowText(string text)
    {
        ClearScreen();
        if (text.Length > 6)
            return;

        InstanceZero(text.Length);

        for (int i = 0; i < text.Length; i++)
        {
            var matchingNumber = _numbers.FirstOrDefault(num => num.CharElement == text[i]);
            InstanceNumber(matchingNumber.Sprite);
        }
    }

    public void ClearScreen()
    {
        _imagesHeader.ForEach((item) => Destroy(item.gameObject));
        _imagesHeader.Clear();
        _numbersInstance.ForEach((e) => Destroy(e.gameObject));
        _numbersInstance.Clear();
        _instanceZeroItems.ForEach((e) => Destroy(e.gameObject));
        _instanceZeroItems.Clear();
    }

    public void Reset()
    {
        _soundService.PlayClick();
        if (_resultValidator != null)
        {
            _resultValidator.Reset();
        }

        if (_algoritmValidator != null)
        {
            _activeString = _levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig).Equation;
            ShowText(_activeString);
            _algoritmValidator.Reset();
        }
    }

    private void UpdateActiveString(int value)
    {
        if (_algoritmValidator.NumberOne == 0)
        {
            UpdateCharacterInString(value);
            _algoritmValidator.SetNumberOne(value);
            return;
        }

        if (_algoritmValidator.NumberTwo == 0)
        {
            UpdateCharacterInString(value);
            _algoritmValidator.SetNumberTwo(value);
        }
    }


    private void InstanceZero(int count)
    {
        _instanceZeroItems.ForEach((e) => Destroy(e.gameObject));
        _instanceZeroItems.Clear();
        for (int i = 0; i < _zero.Count - count; i++)
        {
            var instanceItems = Instantiate(_zero[i], _resultDisplay);
            _instanceZeroItems.Add(instanceItems);
        }
    }

    private void InstanceNumber(GameObject instanceObject)
    {
        var isntanceItem = Instantiate(instanceObject, _resultDisplay);
        _numbersInstance.Add(isntanceItem);
    }
}

public class AlgoritmValidator
{
    private LevelsConfig _levelsConfig;
    private DisplayCalculator _displayCalculator;
    private DisplayShowResult _displayShowResult;
    private int _targetNumber;
    private int _targetNumberTwo;

    private int _numberOne = 0;
    private int _numberTwo = 0;

    public int NumberOne => _numberOne;
    public int NumberTwo => _numberTwo;

    public AlgoritmValidator(LevelsConfig levelsConfig, DisplayShowResult displayShowResult)
    {
        _levelsConfig = levelsConfig;
        _targetNumber = _levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig).TargetNumberOne;
        _targetNumberTwo = _levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig).TargetNumberTwo;
        _displayCalculator = ServiceLocator.Instance.GetService<DisplayCalculator>();
        _displayShowResult = displayShowResult;
    }

    public void SetNumberOne(int value)
    {
        _numberOne = value;
    }

    public void SetNumberTwo(int value)
    {
        _numberTwo = value;
        Valid();
    }

    private void Valid()
    {
        if (_numberOne == _targetNumber && _numberTwo == _targetNumberTwo)
        {
            _levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig + 1);
            _displayCalculator.ShowGameAritmeticsScreen();
        }
    }

    public void Reset()
    {
        _numberOne = 0;
        _numberTwo = 0;
    }
}


public class ResultValidator
{
    private DisplayCalculator _displayCalculator;
    private LevelsConfig _levelsConfig;
    private int _targetvalue;
    public int Value = 0;
    public int _steps;
    private int _stepsValue;

    public ResultValidator(int targetValue, LevelsConfig levelsConfig)
    {
        _targetvalue = targetValue;
        _displayCalculator = ServiceLocator.Instance.GetService<DisplayCalculator>();
        _levelsConfig = levelsConfig;
        _steps = levelsConfig.GetNumberLevel(levelsConfig.ActiveNumberConfig).Steps;
    }

    public bool AddValue(int valueAdd)
    {
        _stepsValue++;
        if (_steps < _stepsValue)
        {
            Reset();
        }

        if (Value < _targetvalue)
        {
            Value += valueAdd;
            CheckComplited();
            return true;
        }

        return false;
    }

    private void CheckComplited()
    {
        if (Value == _targetvalue)
        {
            _levelsConfig.LevelComplited();
            _displayCalculator.ShowGameNumberScreen();
        }
    }

    public void Reset()
    {
        Value = 0;
        _stepsValue = 0;
    }
}

[Serializable]
public struct CharConfig
{
    [SerializeField] private char _charElement;
    [SerializeField] private GameObject _spriteChar;

    public char CharElement => _charElement;
    public GameObject Sprite => _spriteChar;
}