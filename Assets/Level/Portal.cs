using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    public GameObject move;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            player.transform.position = respawn.transform.position;
            move.transform.position = new Vector3(1020, 40, 160);
            DataManager.instance.NewGame();
            DataManager.instance.SaveGame();
            SceneManager.LoadScene(nextScene);
            Level.currentLevel = nextScene;
        }
    }
}
