using Unity.VisualScripting;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu.activeInHierarchy == false)
        {
            menu.SetActive(true);
            TogglePause(false);
        }
    }

    public void HideMenu()
    {
        if (menu.activeInHierarchy == true)
        {
            menu.SetActive(false);
            TogglePause(true);
        }
    }
    
  
    public void TogglePause(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f; 
        }
    }
}
