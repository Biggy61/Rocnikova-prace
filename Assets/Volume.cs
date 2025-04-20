using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour, DataPersistance
{
    public AudioMixer mixer;
    float musicVolume;
    float soundEffectVolume;
    public void LoadData(GameData data)
    {
        musicVolume = data.musicVolume;
        soundEffectVolume = data.soundEffectsVolume;
    }

    public void SaveData(ref GameData data)
    {

    }
    void Start()
    {
        mixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat("soundeffects", Mathf.Log10(soundEffectVolume) * 20);
    }

}
