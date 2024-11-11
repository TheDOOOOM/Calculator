using Services;
using UnityEngine;

public class DisableSound : MonoBehaviour
{
    private SoundService _soundServicel;

    private void Start()
    {
        _soundServicel = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void SwitchSound()
    {
        _soundServicel.SwitchSoundActive();
    }
}