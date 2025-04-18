using System;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private GameObject _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _player.GetComponent<Player>().hp -= 100;
            Debug.Log("Hit!");
        }
    }
}
