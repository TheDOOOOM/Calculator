using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CellsConfigs : ScriptableObject, ICellsConfig
{
    [SerializeField] private List<GameObject> _header;
    [SerializeField] private List<GameObject> _cellObjects;

    public List<GameObject> GetConfig()
    {
        return _cellObjects;
    }

    public List<GameObject> GetHeader()
    {
        return _header;
    }
}