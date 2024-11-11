using Services;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private DisplayCalculator _calculator;

    private void Start()
    {
        ServiceLocator.Instance.AddService(_calculator);
    }
}