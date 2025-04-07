using UnityEngine;

public class Sensor : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject trap;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var position = new Vector2(rb.position.x, rb.position.y - 100);
            Instantiate(trap, position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}