using UnityEngine;

public class PlatformFloatingSideways : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool Direction;
    public Player player;
    public float plus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plus = 1.5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var move = rb.transform.position;
        move.x += plus;
        rb.transform.position = move;
        if (plus > 0) { Direction = true; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { plus *= -1; player.plus *= -1; }
    }

}
