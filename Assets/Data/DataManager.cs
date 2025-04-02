using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataManager : MonoBehaviour
{
 private GameData gameData;
 private List<DataPersistance> dataPersistanceOBJ;
 public static DataManager instance {get; private set;}

 private void Awake()
 {
  if (instance != null)
  {
   Debug.LogWarning("More than one DataManager in scene!");
  }
  instance = this;
 }

 public void Start()
 {
  LoadGame();
 }

 public void ExitGame()
 {
  SaveGame();
 }
 public void NewGame()
 {
   gameData = new GameData();
 }

 public void LoadGame()
 {
  if (gameData == null) { NewGame(); }
  
 }

 public void SaveGame()
 {
   
 }
}
