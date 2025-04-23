using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    private string fileName;
    [Header("Volume Storage Config")] [SerializeField]
    private string volumeFileName;
    private GameData gameData;
    private VolumeData volumeData;
    private List<DataPersistance> dataPersistanceOBJ;
    private List<VolumeDataPersistance> volumeDataPersistanceOBJ;
    public static DataManager instance { get; private set; }
    private FileDataHandler dataHandler;
    private FileDataHandler volumeHandler;
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
        this.volumeHandler = new FileDataHandler(Application.persistentDataPath, volumeFileName);
        this.dataPersistanceOBJ = FindAllDataObjects();
        this.volumeDataPersistanceOBJ = FindAllVolumeDataObjects();
        LoadGame();
        LoadVolume();
    }

    public void ExitGame()
    {
        SaveGame();
    }

    public void NewGame()
    {
        //File.Delete(Path.Combine(Application.persistentDataPath, fileName));
        //File.Create(Path.Combine(Application.persistentDataPath, fileName));
        using (var FileWriter = new StreamWriter(Path.Combine(Application.persistentDataPath, fileName), false))
        {
            FileWriter.WriteLine("");
        }

        this.gameData = new GameData();
    }
    public void NewVolume()
    {
        //File.Delete(Path.Combine(Application.persistentDataPath, fileName));
        //File.Create(Path.Combine(Application.persistentDataPath, fileName));
        using (var FileWriter = new StreamWriter(Path.Combine(Application.persistentDataPath, volumeFileName), false))
        {
            FileWriter.WriteLine("");
        }

        this.volumeData = new VolumeData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (gameData == null)
        {
            NewGame();
        }

        foreach (DataPersistance dataPersistance in dataPersistanceOBJ)
        {
            dataPersistance.LoadData(gameData);
        }
    }
    
    public void LoadVolume()
    {
        this.volumeData = volumeHandler.LoadVolume();

        if (volumeData == null)
        {
            NewVolume();
        }

        foreach (VolumeDataPersistance dataPersistance in volumeDataPersistanceOBJ)
        {
            dataPersistance.LoadVolume(volumeData);
        }
    }

    public void SaveGame()
    {
        foreach (DataPersistance dataPersistance in dataPersistanceOBJ)
        {
            dataPersistance.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }
    
    public void SaveVolume()
    {
        foreach (VolumeDataPersistance dataPersistance in volumeDataPersistanceOBJ)
        {
            dataPersistance.SaveVolume(ref volumeData);
        }

        volumeHandler.SaveVolume(volumeData);
    }

    private List<DataPersistance> FindAllDataObjects()
    {
        IEnumerable<DataPersistance> dataPersistancesObjects =
            FindObjectsOfType<MonoBehaviour>().OfType<DataPersistance>();

        return new List<DataPersistance>(dataPersistancesObjects);
    }
    private List<VolumeDataPersistance> FindAllVolumeDataObjects()
    {
        IEnumerable<VolumeDataPersistance> dataPersistancesObjects =
            FindObjectsOfType<MonoBehaviour>().OfType<VolumeDataPersistance>();

        return new List<VolumeDataPersistance>(dataPersistancesObjects);
    }
}