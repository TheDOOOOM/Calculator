using UnityEngine;
using UnityEngine.tvOS;
using UnityEngine.UI;

public class AdapterCells : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayout;
    [SerializeField] private Vector2 _cellsSizeIPhone;
    [SerializeField] private Vector2 _cellsSizeIPad;
    [SerializeField] private bool _isIphone;

    private void Start()
    {
        CheckDevice();
    }

    public void CheckDevice()
    {
        #region Editor Testing

#if UNITY_EDITOR

        if (_isIphone)
        {
            _gridLayout.cellSize = _cellsSizeIPhone;
        }
        else if (!_isIphone)
        {
            _gridLayout.cellSize = _cellsSizeIPad;
        }

#endif
        return;

        #endregion

        var deviceGeneration = Device.generation;

        if (deviceGeneration.ToString().StartsWith("iPhone"))
        {
        }
        else if (deviceGeneration.ToString().StartsWith("iPad"))
        {
            Debug.Log("User is using an iPad.");
        }
    }
}