using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D myRigidbody;
    public GameObject enemy;
    public float speed;
    private float timer = 0f;
    void Start()
    {

    
        myRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 direction = player.transform.position - transform.position;
        myRigidbody.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
        
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        // float distance = Vector3.Distance(myRigidbody.transform.position, enemy.transform.position);
        if (timer >= 10f )
        {
            Destroy(this.gameObject);
        }
    }
}
 
 