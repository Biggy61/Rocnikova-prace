using UnityEngine;
[System.Serializable]
public class VolumeData
{
    public float musicVolume;
    public float soundEffectsVolume;

    public VolumeData()
    {
        musicVolume = 0.5f;
        soundEffectsVolume = 0.5f;
    }
}
