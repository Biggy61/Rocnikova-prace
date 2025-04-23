using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour, VolumeDataPersistance
{
    public AudioMixer mixer;
    float musicVolume;
    float soundEffectVolume;

    public void LoadVolume(VolumeData data)
    {
        musicVolume = data.musicVolume;
        soundEffectVolume = data.soundEffectsVolume;
    }

    public void SaveVolume(ref VolumeData data)
    {
        
    }


    void Start()
    {
        mixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat("soundeffects", Mathf.Log10(soundEffectVolume) * 20);
    }

}
