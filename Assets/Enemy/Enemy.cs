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
    public float speed = 5f;
    public float distance = 200f;
    private Vector3 leftPoint;
    private Vector3 rightPoint;
    private bool movingRight = true;
    public float checkDistance;
    AudioManager audioManager;
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
        //Debug.Log("saving ");
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
        player = GameObject.FindGameObjectWithTag("Player");
        score = GameObject.FindGameObjectWithTag("Score");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        leftPoint = transform.position + Vector3.left * distance;
        rightPoint = transform.position + Vector3.right * distance;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Update is called once per frame
    void Update()
    {
        Death();
        Walk();
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


    void Death()
    {
        if (hp <= 0)
        {
            enemiesKilled = true;
            Destroy(gameObject);
            score.GetComponent<Score.Score>().score += 50;
            audioManager.PlaySoundEffects(audioManager.kill);
        }
    }

    void Walk()
    {

        
        if (walk) { animator.SetTrigger("Walk"); }
        
        else { animator.SetTrigger("Idle"); }

        float distancePlayerEnenemy = Vector3.Distance(player.transform.position, transform.position);
        bool visible = player.transform.position.y < transform.position.y + checkDistance &&
                       player.transform.position.y > transform.position.y - 20;
        if (distancePlayerEnenemy < 300 & visible)
        {
            walk = false;
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
        else
        {
            walk = true;
            if (movingRight)
            {
                FlipPositive();
                transform.position += Vector3.right * (speed * Time.deltaTime);
                if (transform.position.x >= rightPoint.x)
                    movingRight = false;
            }
            else
            {
                FlipNegative();
                transform.position += Vector3.left * (speed * Time.deltaTime);
                if (transform.position.x <= leftPoint.x)
                    movingRight = true;
            }
        }
    }
}
    
    
   



