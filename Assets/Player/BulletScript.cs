using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D myRigidbody;
    private Vector2 plus;

    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindGameObjectWithTag("Player");
        // Vector2 direction = player.transform.position.x , player.transform.position.y;
        // myRigidbody.linearVelocity = new Vector2(direction.x, myRigidbody.transform.position.y).normalized * speed;
        //
    }

    void Update()
    {
        plus = myRigidbody.transform.position;
        plus.x += 1;
        myRigidbody.transform.position = plus;
        float distance = Vector3.Distance(myRigidbody.transform.position, player.transform.position);
        if (distance > 300 )
        {
            Destroy(this.gameObject);
        }
    }
}
 
 