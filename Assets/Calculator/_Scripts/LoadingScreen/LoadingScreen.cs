using Cysharp.Threading.Tasks;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        ServiceLocator.Init();
        LoadNextScreen();
    }

    private async void LoadNextScreen()
    {
        var loadProgrees = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!loadProgrees.isDone)
        {
            _slider.value = loadProgrees.progress;
            await UniTask.Yield(PlayerLoopTiming.Update);
        }
    }
}