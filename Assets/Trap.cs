using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector2.Distance(player.transform.position, transform.position);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + 2f);
        

        

        
    }
}
