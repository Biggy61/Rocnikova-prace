using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D myRigidbody;
    public GameObject enemy;
    public float speed;

    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 direction = player.transform.position - transform.position;
        myRigidbody.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        
    }

    void Update()
    {
        float distance = Vector3.Distance(myRigidbody.transform.position, enemy.transform.position);
        if (distance > 300 )
        {
            Destroy(this.gameObject);
        }
        Debug.Log(distance);
    }
}
 
 