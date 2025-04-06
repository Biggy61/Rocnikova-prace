using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject respawn;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag("Respawn");
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
    }
}