using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public GameObject player;
    public GameObject score;
    void Start()
    {
      score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        Check();
        Death();
    }

    void FlipNegative()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = -1;
        transform.localScale = newScale;
    }
    void FlipPositive()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = 1;
        transform.localScale = newScale;
    }

    void Check()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var playerPos = player.transform.position.x;
        var enemyPos = transform.position.x;
        bool visible = player.transform.position.y < transform.position.y + 20 && player.transform.position.y > transform.position.y - 20;
        if (playerPos > enemyPos && visible)
        {
            FlipPositive();
        }

        if (playerPos < enemyPos && visible)
        {
            FlipNegative();
        }

    }

    void Death()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            score.GetComponent<Score.Score>().score += 50;
        }  
    }
}

