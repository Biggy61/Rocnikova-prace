using System;
using UnityEngine;

public class Princess : MonoBehaviour
{
    public GameObject text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            text.SetActive(true);
        }

    }
}
