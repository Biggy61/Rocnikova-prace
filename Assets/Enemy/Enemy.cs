using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, DataPersistance
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid of ID")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public int hp;
    public GameObject player;
    public GameObject score;
    private bool enemiesKilled = false;
    public Animator animator;
    public Rigidbody2D rb;
    public bool walk;
    public float distance;
    public void LoadData(GameData data)
    {
        //Debug.Log("blablabla");
        data.enemiesKilled.TryGetValue(id, out enemiesKilled);
        //Debug.Log("enemy : "+ id  + enemiesKilled);
        if (enemiesKilled)
        {
            //Debug.Log("IT WORKS!");
            this.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("saving ");
        //pokud uz je v Dictionary tam se vymaze a prida znovu
        if (data.enemiesKilled.ContainsKey(id))
        {
            data.enemiesKilled.Remove(id);
        }

        data.enemiesKilled.Add(id, enemiesKilled);
        Debug.Log(id + enemiesKilled);
    }

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        rb = GetComponent<Rigidbody2D>();
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
        bool visible = player.transform.position.y < transform.position.y + 20 &&
                       player.transform.position.y > transform.position.y - 20;
        if (playerPos > enemyPos && visible)
        {
            FlipPositive();
        }

        if (playerPos < enemyPos && visible)
        {
            FlipNegative();
        }

        Walk();
    }

    void Death()
    {
        if (hp <= 0)
        {
            enemiesKilled = true;
            Destroy(gameObject);
            score.GetComponent<Score.Score>().score += 50;
        }
    }

    void Walk()
    {
       Vector2 left;
       Vector2 right;

        if (walk)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        float distancePlayerEnenemy = Vector3.Distance(player.transform.position, transform.position);
        bool visible = player.transform.position.y < transform.position.y + distance &&
                       player.transform.position.y > transform.position.y - 20;
        if (distancePlayerEnenemy < 300 & visible)
        {
            walk = false;
        }
        else
        {
            walk = true;
        }
    }
}
    
    
   



