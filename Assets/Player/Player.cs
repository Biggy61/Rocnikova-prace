using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, DataPersistance
{
    public Animator animator;
    public Rigidbody2D rb;
    public int hp;
    public int maxHealth = 100;
    public int characterSpeed;
    public int jump;
    public int jumpPower;
    public GameObject respawn;
    public float horizontal;
    public float castDistance;
    public LayerMask groundLayer;
    [SerializeField] float fallMultiplier;
    public Vector2 gravityVector;
    public bool isGrounded => groundScript.isGrounded;
    public Transform groundCheck;
    public float plus = 1.4f;
    private GameObject _standingOn;
    AudioManager audioManager;
    public bool IsDead = false;
    public bool IsMoving;
    public PlayerGroundScript groundScript;
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        this.hp = data.playerHp;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = transform.position;
        data.playerHp = hp;
    }

    void Start()
    {
        gravityVector = new Vector2(0, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        //healthBar.SetMaxHealth(maxHealth);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlaySoundEffects(audioManager.lvl);
        groundScript = transform.GetChild(1).gameObject.GetComponent<PlayerGroundScript>();
    }


    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, castDistance, groundLayer);

        if (!isGrounded)
        {
            animator.SetTrigger("Jump");
        }
        

        if (Input.GetKey(KeyCode.Space) && isGrounded == true && IsAlive())
        {
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * jumpPower);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
              groundScript.isGrounded = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && groundScript.canDoubleJump && IsAlive() && !isGrounded)
        {
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * jumpPower);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            groundScript.canDoubleJump = false;
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && isGrounded && IsAlive())
        {
            animator.SetTrigger("Move");
        }

        if (rb.linearVelocity.magnitude > 1f)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }

        //healthBar.SetHealth(hp);
        if (IsAlive())
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(horizontal * characterSpeed, rb.linearVelocity.y);
            if (horizontal != 0) transform.localScale = new Vector3(horizontal, 1, 1);
        }

        if (!IsAlive())
        {
            animator.SetTrigger("Death");
            
        }


        //rb.AddForce(gravityVector * (fallMultiplier / 100), ForceMode2D.Impulse);
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += gravityVector * (fallMultiplier * Time.deltaTime);
        }

        FallDeath();

        Respawn();

        if (!IsAlive() && !IsDead)
        {
            audioManager.PlaySoundEffects(audioManager.death);
            IsDead = true;
        }
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
            hp = 0;
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
        if (IsAlive())
        {
            respawn.SetActive(!true);
        }
        else
        {
            respawn.SetActive(true);
        }
    }


}