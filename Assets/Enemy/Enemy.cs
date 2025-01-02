using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public GameObject player;
    private bool flip;
    private bool flip1;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Check();
        if (hp <= 0) { Destroy(gameObject); }  

    }

    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = -1;
        transform.localScale = newScale;
    }
    void Flip1()
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
            flip = true;
        }
        else
        {
            flip = false;
        }
        
        if (playerPos < enemyPos)
        {
            flip1 = true;
        }
        else
        {
            flip1 = false;
        }

        if (flip)
        {
            Flip1();
        }
        if (flip1)
        {
            Flip();
        }
    }
}

