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
        if (playerPos > enemyPos)
        {
            FlipPositive();
        }

        if (playerPos < enemyPos)
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

