using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D myRigidbody;
    private Vector2 plus;
    private Vector2 minus;
    private float direction;
    private float timer = 0;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.localScale.x;
    }

    void Update()
    {
        timer += Time.deltaTime;
        Direction();
        Death();
    }

    void Direction()
    {
        if (direction == 1)
        {
            plus = myRigidbody.transform.position;
            plus.x += 2;
            myRigidbody.transform.position = plus;
        }

        if (direction == -1)
        {
            minus = myRigidbody.transform.position;
            minus.x -= 2;
            myRigidbody.transform.position = minus;
        }
    }


    void Death()
    {
        // float distance = Vector3.Distance(myRigidbody.transform.position, player.transform.position);
        if (timer >= 5f)
        {
            Destroy(this.gameObject);
        }
    }
}