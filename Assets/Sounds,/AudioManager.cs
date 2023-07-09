using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Pixelplacement;

[System.Serializable]
public class SoundItem
{
    public string name;
    public AudioClip[] source;
    [Range(0, 1)]
    public float volume = 1;

}
public class AudioManager : Singleton<AudioManager>
{
    AudioSource _audioSource;
    public List<SoundItem> sounds;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }
    public void PlaySound(string audioName)
    {

        //      sound[Random.Range(0,sound.Length)].Play();

        foreach (SoundItem si in sounds)
        {
            if (si.name == audioName)
            {
                AudioClip sound = si.source[
        Random.Range(0, si.source.Length)
        ];

                _audioSource.volume = si.volume;
                _audioSource.PlayOneShot(sound);
            }
        }




    }
}
