using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour, DataPersistance
{
  public AudioMixer mixer;
  public Slider musicSlider;
  public Slider soundEffectSlider;
  public float musicVolume;
  public float soundEffectsVolume;

  private void Start()
  {
      SetMusicVolume();
      SetSoundEffectVolume();

  }
  public void LoadData(GameData data)
  {
     musicSlider.value = data.musicVolume;
     soundEffectSlider.value = data.soundEffectsVolume;
  }

  public void SaveData(ref GameData data)
  {
    data.musicVolume = musicSlider.value;
    data.soundEffectsVolume = soundEffectSlider.value;
  }

  public void SetMusicVolume()
  {
    musicVolume = musicSlider.value;
    mixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
  }

  public void SetSoundEffectVolume()
  {
    soundEffectsVolume = soundEffectSlider.value;
    mixer.SetFloat("soundeffects", Mathf.Log10(soundEffectsVolume) * 20);
  }
  
}

