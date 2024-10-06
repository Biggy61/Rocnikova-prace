using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidbody;
    public int hp;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public int characterSpeed;
    public int jump;
    public int jumpPower;
    public float horizontal; 
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    { 
        healthBar.SetHealth(hp);
        horizontal = Input.GetAxisRaw("Horizontal");
        myRigidbody.velocity = new Vector2(horizontal * characterSpeed, myRigidbody.velocity.y);
        if (horizontal != 0) this.transform.localScale = new Vector3(horizontal, 1, 1);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jump * jumpPower);
        }
       


    }
    
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize , 0, -transform.up, castDistance, groundLayer))
        {
             return true;
        }
        else
        {
            return false;
        }
    }
   
}