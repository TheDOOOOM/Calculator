using System;
using TMPro;
using UnityEngine;

public class TargetValue : MonoBehaviour, IService
{
    [SerializeField] private TextMeshProUGUI _steps;
    [SerializeField] private TextMeshProUGUI _target;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetTargetValue(int steps, int tagetNubmer)
    {
        _steps.text = $"Steps:{steps}";
        _target.text = $"Target:{tagetNubmer}";
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}