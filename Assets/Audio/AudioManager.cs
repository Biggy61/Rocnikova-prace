using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public AudioSource music;
   public AudioSource soundEffects;
   public AudioClip background;
   public AudioClip death;
   public AudioClip heal;
   public AudioClip lvl;

   public void Start()
   {
      music.clip = background;
      music.Play();
   }

   public void PlaySoundEffects(AudioClip clip)
   {
      soundEffects.PlayOneShot(clip);
   }
}
