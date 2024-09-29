using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D MyRigidbody;
    public int characterSpeed;
    public int jump;
    public int jumpPower;
    public float horizontal;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        MyRigidbody.velocity = new Vector2(horizontal * characterSpeed, MyRigidbody.velocity.y);
        if (horizontal != 0) this.transform.localScale = new Vector3(horizontal, 1, 1);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, jump * jumpPower);
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

 
       private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
        }
   
}