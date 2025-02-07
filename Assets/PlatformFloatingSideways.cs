using UnityEngine;

public class PlatformFloatingSideways : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 move;

    private float plus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plus = 0.2f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = rb.transform.position;
        move.x += plus;
        rb.transform.position = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            plus *= -1;
        }
    }
}
