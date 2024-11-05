using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        LoadNextScreen();
    }

    private async void LoadNextScreen()
    {
        var loadProgrees = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!loadProgrees.isDone)
        {
            await UniTask.Yield(PlayerLoopTiming.Update);
        }
    }
}