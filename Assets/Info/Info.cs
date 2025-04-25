using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject info;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.F1) && info.activeInHierarchy == false)
        {
            info.SetActive(true);
            //TogglePause(false);
        }
    }

    public void HideInfo()
    {
        if (info.activeInHierarchy == true)
        {
            info.SetActive(false);
            //TogglePause(true);
        }
    }
    
  
    // public void TogglePause(bool isPaused)
    // {
    //     if (isPaused)
    //     {
    //         Time.timeScale = 1f;
    //     }
    //     else
    //     {
    //         Time.timeScale = 0f; 
    //     }
    //}
    
}
