using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour, DataPersistance
{
    public float musicVolume;
    public float effectsVolume;
    void Start()
    {
        
    }
    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {
        //data.musicVolume = musicVolume;
        //data.soundEffectsVolume = effectsVolume;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void StartButton()
    {
        
        DataManager.instance.SaveGame();
        SceneManager.LoadScene(Level.currentLevel);
    }

    public void NewGameButton()
    {
        DataManager.instance.NewGame();
        Level.currentLevel = 2;
    }
}
