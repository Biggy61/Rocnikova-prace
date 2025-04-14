using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
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
        SceneManager.LoadScene(Level.currentLevel);
    }

    public void NewGameButton()
    {
        DataManager.instance.NewGame();
        Level.currentLevel = 2;
    }
}
