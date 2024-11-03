using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;
    public GameObject enemy;
    void Start() { }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {

       Collider2D[] hit =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

       foreach (Collider2D enemy in hit)
       {
           enemy.GetComponent<Enemy>().hp -= 10;
       }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
