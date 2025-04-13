using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour, DataPersistance
{
    public static int currentLevel;
  
    public void LoadData(GameData data)
    {
        currentLevel = data.currentLevel;
    }

    public void SaveData(ref GameData data)
    {
        data.currentLevel = currentLevel;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            currentLevel = 3;
        }
    }

    public void StartButton()
    {
        DataManager.instance.SaveGame();
        SceneManager.LoadScene(currentLevel);
    }

    public void NewGameButton()
    {
        DataManager.instance.NewGame();
        currentLevel = 2;
    }
}
