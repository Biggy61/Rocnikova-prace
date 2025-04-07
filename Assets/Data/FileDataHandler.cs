using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;

public class FileDataHandler
{
  private string dataDirectoryPath = "";
  private string dataFileName = "";

  public FileDataHandler(string dataDirectoryPath, string dataFileName)
  {
    this.dataDirectoryPath = dataDirectoryPath;
    this.dataFileName = dataFileName;
  }
//15:59
  public GameData Load()
  {
    //Path.Combine protoze ruzne operacni systemy maji ruzne separatory
    string fullPath = Path.Combine(dataDirectoryPath, dataFileName);
    GameData loadedData = null;
    if (File.Exists(fullPath))
    {
      try
      {
        //Loadnout serialized data z souboru
        string dataToLoad = "";
        //Open protoze chci cist z yoho souboru
        using (FileStream stream = new FileStream(fullPath, FileMode.Open))
        {
          using (StreamReader reader = new StreamReader(stream))
          {
            dataToLoad = reader.ReadToEnd();

          }
        }
        //Desearilovat data z Json zpatky do C# objectu
        loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
      }
      catch (Exception e)
      {
        Debug.LogError("Error occured in FileDataHandler: " + e);
      }
    }
    return loadedData;
    
  }

  public void Save(GameData data)
  {
    //Path.COmbine protoze ruzne operacni systemy maji ruzne separatory
    string fullPath = Path.Combine(dataDirectoryPath, dataFileName);
    try
    {
      //vytvoreni slozky do ktere se ten soubor vytvori pokud jeste neexistuje
      Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
      
      //serialize C# gamedata do objectu v JSON
      string dataToStore = JsonUtility.ToJson(data, true);
      
      //napsat data do souboru
      using (FileStream stream = new FileStream(fullPath, FileMode.Create))
      {
        using (StreamWriter writer = new StreamWriter(stream))
        {
          writer.Write(dataToStore);
        }
      }
    }
    catch (Exception e)
    {
      Debug.LogError("Error occured in FileDataHandler: " + e);
    }
    
  }
}
