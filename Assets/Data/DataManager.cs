using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataManager : MonoBehaviour
{
 [Header("File Storage Config")] 
 [SerializeField] private string fileName;
 private GameData gameData;
 private List<DataPersistance> dataPersistanceOBJ;
 public static DataManager instance {get; private set;}

 private FileDataHandler dataHandler;
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
  //persistentDataPath - da OS standartni directory pro unity project
  this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
  this.dataPersistanceOBJ = FindAllDataObjects();
  LoadGame();
 }

 public void ExitGame()
 {
  SaveGame();
 }
 public void NewGame()
 {
   this.gameData = new GameData();
 }

 public void LoadGame()
 {
  this.gameData = dataHandler.Load();
  
  if (gameData == null) { NewGame(); }

  foreach (DataPersistance dataPersistance in dataPersistanceOBJ)
  {
   dataPersistance.LoadData(gameData);
  }
  
  Debug.Log("Load count: " + gameData.score);
 }

 public void SaveGame()
 {
  foreach (DataPersistance dataPersistance in dataPersistanceOBJ)
  {
   dataPersistance.SaveData(ref gameData);
  }
  Debug.Log("Save count: " + gameData.score);
  dataHandler.Save(gameData);
 }

 private List<DataPersistance> FindAllDataObjects()
 {
  IEnumerable<DataPersistance> dataPersistancesObjects = FindObjectsOfType<MonoBehaviour>().OfType<DataPersistance>();
  
  return new List<DataPersistance>(dataPersistancesObjects);
 }
}
