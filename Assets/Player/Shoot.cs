using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public Animator animator;
    public GameObject player;
    public int hp;
    public Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    { 
         timer += Time.deltaTime;
         hp = player.GetComponent<Player>().hp;
         if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.E) && timer > 0.3f && hp > 0 && !playerScript.IsMoving)
         {
             shoot();
             animator.SetTrigger("Attack");
             timer = 0;
         }

        }

        void shoot()
        { 
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }

