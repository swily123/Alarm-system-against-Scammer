using System.Collections;
using UnityEngine;

public class SoundEngineer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private const float VolumeSmoothTime = 0.1f;

    private void Awake()
    {
        _audioSource.volume = 0;
        _audioSource.Stop();
    }

    public void ToggleActive(bool isEnter)
    {
        if (isEnter)
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }

            PlaySound(1);
        }
        else
        {
            PlaySound(0);
        }
    }

    private void PlaySound(float targetVolume)
    {
        StopAllCoroutines();
        StartCoroutine(TowardsVolumeWhile(targetVolume));
    }

    private IEnumerator TowardsVolumeWhile(float targetVolume)
    {

        while (enabled)
        {
            var currentVolume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime * VolumeSmoothTime);
            _audioSource.volume = currentVolume;

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
                yield break;
            }

            yield return null;
        }
    }
}
