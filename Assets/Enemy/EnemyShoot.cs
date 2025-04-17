using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;
    private float timer;

    public float view;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distancePlayerEnenemy = Vector3.Distance(player.transform.position, transform.position);
        bool visible = player.transform.position.y < transform.position.y + view &&
                       player.transform.position.y > transform.position.y - 20;
        if (distancePlayerEnenemy < 300 & visible)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                shoot();
            }
        }

        //Debug.Log(distancePlayerEnenemy);

        void shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
}