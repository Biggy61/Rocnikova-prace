using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject respawn;
    public GameObject player;
    public GameObject level;
    public GameObject move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        move = GameObject.FindGameObjectWithTag("Move");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnButton()
    {
        Debug.Log("Respawn");
        player.GetComponent<Player>().hp = 100;
        player.transform.position = respawn.transform.position;
        move.transform.position = new Vector3(1020, 40, 160);
        DataManager.instance.SaveGame();
        SceneManager.LoadScene(Level.currentLevel);

    }
}