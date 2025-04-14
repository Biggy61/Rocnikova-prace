using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, DataPersistance
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

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            currentLevel = 3;
            Debug.Log(currentLevel);
        }
    }
}
