using UnityEngine;

public interface VolumeDataPersistance
{
  
  void LoadVolume(VolumeData data);
  
  void SaveVolume(ref VolumeData data);
}
