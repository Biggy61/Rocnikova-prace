using UnityEngine;

public class Trap : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 plus;
    private float start;
    private float end;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        start = rb.transform.position.y;
        end = rb.transform.position.y + 200;
    }

    // Update is called once per frame
    void Update()
    {
        if(start < end)
        {
            plus = rb.transform.position;
            plus.y += 1.5f;
            rb.transform.position = plus;
            start += 1.5f;
        }

        if (start >= end)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.GetComponent<Player>().hp -= 100;
            Debug.Log("Hit!");
        }
    }
}