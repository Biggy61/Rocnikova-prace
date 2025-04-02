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
        }
    }

    public void HideMenu()
    {
        if (menu.activeInHierarchy == true)
        {
            menu.SetActive(false);
        }
    }
}
