using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
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

