using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICellsConfig
{
    public List<GameObject> GetConfig();
    public List<GameObject> GetHeader();
}