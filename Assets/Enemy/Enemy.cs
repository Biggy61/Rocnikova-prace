using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var playerPos = player.transform.position.x;
        var enemyPos = transform.position.x;
        if (playerPos > enemyPos)
        { 
            Flip();
        }
        if (hp <= 0) { Destroy(gameObject); }  

    }

    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
