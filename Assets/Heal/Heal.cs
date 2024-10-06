using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.name == "Player")
        {
            if (player.GetComponent<Player>().hp < 100)
            {
                player.GetComponent<Player>().hp += 10;
            }

            
            Debug.Log("Healed");
        }


    }
}
