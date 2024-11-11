using System.Collections.Generic;
using Services;
using Unity.VisualScripting;
using UnityEngine;

public class ItemsBuilder : MonoBehaviour
{
    private DisplayShowResult _displayShowResult;

    private List<GameObject> _showObjects = new();

    public void Init()
    {
        _displayShowResult = ServiceLocator.Instance.GetService<DisplayShowResult>();
    }

    public void BuildCeels(ICellsConfig config, Transform transformConteiner)
    {
        ClearScreen();
        _displayShowResult.ShowHeader(config);
        InstanceItems(config, transformConteiner);
    }

    private void InstanceItems(ICellsConfig config, Transform conteiner)
    {
        var cells = config.GetConfig();
        for (int i = 0; i < cells.Count; i++)
        {
            var instance = Instantiate(cells[i], conteiner);
            _showObjects.Add(instance);
        }
    }

    private void ClearScreen() => _showObjects.ForEach((screenElement) => Destroy(screenElement.GameObject()));
}