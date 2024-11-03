using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;
    public GameObject enemy;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distancePlayerEnenemy = Vector3.Distance(player.transform.position, enemy.transform.position);

        if (distancePlayerEnenemy < 175)
        {
         timer += Time.deltaTime;
        if (timer >2)
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
