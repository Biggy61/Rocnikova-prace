using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject player;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            score.GetComponent<Score.Score>().score += 10;
            if (player.GetComponent<Player>().hp < 100)
            {
                player.GetComponent<Player>().hp += 10;
                Debug.Log("Healed");
            }

            
            
        }


    }
}
