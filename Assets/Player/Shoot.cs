using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
         if (Input.GetMouseButtonDown(0) && timer > 1f)
         {
             shoot();
             timer = 0;
         }

        }

        void shoot()
        { 
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }

