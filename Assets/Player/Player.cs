using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public int hp;
    private int extraJump;
    public int extraJumpValue;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public int characterSpeed;
    public int jump;
    public int jumpPower;
    public GameObject respawn;
    public float horizontal;
    public float castDistance;
    public LayerMask groundLayer;
    [SerializeField] float fallMultiplier;
    public Vector2 gravityVector;
    public bool isGrounded;
    public Transform groundCheck;
    public float plus = 1.4f;
    private GameObject _standingOn;

    void Start()
    {
        extraJump = extraJumpValue;
        gravityVector = new Vector2(0, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, castDistance, groundLayer); 
        
        if (!isGrounded) { animator.SetTrigger("Jump"); }
        if (isGrounded == true) { extraJump = extraJumpValue; }
        
        if (Input.GetKey(KeyCode.Space) && isGrounded == true && IsAlive())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * jumpPower);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0 && IsAlive())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * jumpPower);
            extraJump--;
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && isGrounded && IsAlive())
        {
            animator.SetTrigger("Move");
        }

        healthBar.SetHealth(hp);
        if (IsAlive())
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(horizontal * characterSpeed, rb.linearVelocity.y);

            if (horizontal != 0) transform.localScale = new Vector3(horizontal, 1, 1);
        }
        
        if (!IsAlive()) { animator.SetTrigger("Death"); }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += gravityVector * fallMultiplier * Time.deltaTime;
        }
        FallDeath();
        
        Respawn();
    }

    private void FixedUpdate()
    {
        ApplyMove();
    }
    private bool IsAlive()
    {
        return hp > 0;
    }

    private void FallDeath()
    {
        if (rb.position.y <= -130)
        {
            hp -= 100;
        }
    }
    private void ApplyMove()
    {
        if (_standingOn is not null)
        {
            var move = rb.transform.position;
            move.x += _standingOn.GetComponent<PlatformFloatingSideways>().plus;
            rb.transform.position = move;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Move"))
        {
            _standingOn = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Move"))
        {
            _standingOn = null;
        }
    }


    public void Respawn()
    { 
        if (IsAlive()) { respawn.SetActive(!true); }
        else { respawn.SetActive(true); }
    }
}