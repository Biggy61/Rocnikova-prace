using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    private Vector2 plus;
    private Vector2 end;
    public Rigidbody2D trapRb;
    private bool set;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        set = false;
        end = trapRb.transform.position;
        end.y += 400;
    }

    // Update is called once per frame
    void Update()
    {
        while (set == true)
        {

            while (end.y > plus.y)
            {
                plus = trapRb.transform.position;
                plus.y += 1;
                trapRb.transform.position = plus;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            set = true;
        }
    }
}