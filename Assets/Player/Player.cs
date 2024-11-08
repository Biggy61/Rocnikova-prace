using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
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
    [SerializeField] float fallMultiplier;
    public Vector2 gravityVector;

    void Start()
    {
        gravityVector = new Vector2(0, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded()) { animator.SetTrigger("Jump"); }
        if (Input.GetKey(KeyCode.A) || IsGrounded())  { animator.SetTrigger("Move"); }
        healthBar.SetHealth(hp);
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * characterSpeed, rb.velocity.y);
        if (horizontal != 0) this.transform.localScale = new Vector3(horizontal, 1, 1);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * jumpPower);
        }

        if (hp <= 0) {animator.SetTrigger("Death"); }

        if (rb.velocity.y < 0)
        {
            rb.velocity += gravityVector * fallMultiplier * Time.deltaTime;
        } 

    }
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}