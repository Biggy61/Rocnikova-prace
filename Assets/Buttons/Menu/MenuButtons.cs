using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EndGameButton()
    {
        DataManager.instance.SaveGame();
        Application.Quit();
        Debug.Log("Quit");
    }

    public void BackToMainMenu()
    {
        DataManager.instance.SaveGame();
        SceneManager.LoadScene(0);
    }
}
