using Calculator._Scripts.SO;
using Services;
using UnityEngine;

public class DisplayCalculator : MonoBehaviour, IService
{
    [SerializeField] private SoundService _soundService;
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private CellsConfigs _menuConfg;
    [SerializeField] private CellsConfigs _settingsConfig;
    [SerializeField] private CellsConfigs _gameMenuConfig;
    [SerializeField] private CellsConfigs _exitConfig;
    [SerializeField] private DisplayShowResult _displayShowResult;
    [SerializeField] private ItemsBuilder _itemsBuilder;
    [SerializeField] private TargetValue _targetValue;
    [SerializeField] private Transform _transformConteiner;

    private void Start()
    {
        ServiceLocator.Instance.AddService(_displayShowResult);
        ServiceLocator.Instance.AddService(_targetValue);
        ServiceLocator.Instance.AddService(_soundService);
        _itemsBuilder.Init();
        ShowMenu();
    }

    public void ShowMenu()
    {
        _itemsBuilder.BuildCeels(_menuConfg, _transformConteiner);
        _soundService.PlayClick();
        _targetValue.Disable();
    }

    public void ShowGameMenu()
    {
        _itemsBuilder.BuildCeels(_gameMenuConfig, _transformConteiner);
        _soundService.PlayClick();
        _targetValue.Disable();
    }

    public void ShowGameNumberScreen()
    {
        var level = _levelsConfig.GetNumberLevel(_levelsConfig.ActiveNumberConfig);
        _itemsBuilder.BuildCeels(level.CellsConfigs, _transformConteiner);
        _displayShowResult.ActiveLevel();
        _soundService.PlayClick();
    }

    public void ShowGameAritmeticsScreen()
    {
        var level = _levelsConfig.GetAritmeticsLevel(_levelsConfig.ActiveArithmeticsConfig);
        _itemsBuilder.BuildCeels(level.CellsConfig, _transformConteiner);
        _displayShowResult.SetAlgoritm(level.Equation);
        _soundService.PlayClick();
    }

    public void ShowSettings()
    {
        _itemsBuilder.BuildCeels(_settingsConfig, _transformConteiner);
        _soundService.PlayClick();
        _targetValue.Disable();
    }

    public void ShowExitScreen()
    {
        _itemsBuilder.BuildCeels(_exitConfig, _transformConteiner);
        _soundService.PlayClick();
        _targetValue.Disable();
    }
}