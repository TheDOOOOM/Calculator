using UnityEngine;

public class SoundService : MonoBehaviour, IService
{
    [SerializeField] private AudioSource _buttonClik;

    private bool _soundActive = true;

    public void PlayClick()
    {
        if (_soundActive)
        {
            _buttonClik.Play();
        }
    }

    public void SwitchSoundActive()
    {
        var value = !_soundActive;
        _soundActive = value;
    }
}