using System;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator._Scripts.SO
{
    [CreateAssetMenu(fileName = "LevelsConfigs", menuName = "LevelsConfig")]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _numbersConfig;
        [SerializeField] private List<ArithmeticConfig> _arithmetics;

        public int ActiveNumberConfig;
        public int ActiveArithmeticsConfig;

        public LevelConfig GetNumberLevel(int levelConfig)
        {
            if (levelConfig > _numbersConfig.Count)
            {
                ActiveNumberConfig = 0;
                return _numbersConfig[0];
            }

            ActiveNumberConfig = levelConfig;
            return _numbersConfig[levelConfig];
        }

        public ArithmeticConfig GetAritmeticsLevel(int ArithmeticsLevel)
        {
            if (ArithmeticsLevel > _numbersConfig.Count)
            {
                ActiveNumberConfig = 0;
                return _arithmetics[0];
            }

            ActiveArithmeticsConfig = ArithmeticsLevel;
            return _arithmetics[ArithmeticsLevel];
        }

        public void LevelComplited()
        {
            ActiveNumberConfig++;
        }

        public void Reset()
        {
            ActiveNumberConfig = 0;
            ActiveArithmeticsConfig = 0;
        }
    }


    [Serializable]
    public struct LevelConfig
    {
        [SerializeField] private CellsConfigs _cellsConfig;
        [SerializeField] private int _steps;
        [SerializeField] private int _targetNumber;
        [SerializeField] private int _valueOne;
        [SerializeField] private int _valueTwo;

        public int TargetNumber => _targetNumber;
        public int Steps => _steps;
        public CellsConfigs CellsConfigs => _cellsConfig;
        public int ValueOne => _valueOne;
        public int ValueTwo => _valueTwo;
    }

    [Serializable]
    public struct ArithmeticConfig
    {
        [SerializeField] private CellsConfigs _cellsConfigs;
        [SerializeField] private string _equation;
        [SerializeField] private int _targetNumberOne;
        [SerializeField] private int _targetNumberTwo;
        [SerializeField] private int _numberOne;
        [SerializeField] private int _numberTwo;

        public CellsConfigs CellsConfig => _cellsConfigs;
        public string Equation => _equation;
        public int TargetNumberOne => _targetNumberOne;
        public int TargetNumberTwo => _targetNumberTwo;
        public int TargetNumberOFree => _numberOne;
        public int TargetNumberFour => _numberTwo;
    }
}