using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float musicVolume;
    public float effectsVolume;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartButton()
    {
        
        DataManager.instance.SaveGame();
        DataManager.instance.SaveVolume();
        SceneManager.LoadScene(Level.currentLevel);
    }

    public void NewGameButton()
    {
        DataManager.instance.NewGame();
        Level.currentLevel = 2;
        Time.timeScale = 1f;
    }
}
