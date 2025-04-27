using UnityEngine;

public class PlatformFloatingSideways : MonoBehaviour, DataPersistance
{
    public Rigidbody2D rb;

    public bool Direction;
    public Player player;
    public GameObject playerObject;
    public float plus;
    private bool standingOnPlatform = false;
    public void LoadData(GameData data)
    {
        this.transform.position = data.movingPlatformPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.movingPlatformPosition =  this.transform.position;
    }
    void Start()
    {
        plus = 1.5f;
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (standingOnPlatform  && playerObject.GetComponent<Player>().hp > 0)
        {
            var move = rb.transform.position;
            move.x += plus;
            rb.transform.position = move;
            if (plus > 0) { Direction = true; } 
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { plus *= -1; player.plus *= -1; }

        if (collision.gameObject.CompareTag("Player"))
        {
            standingOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            standingOnPlatform = false;
        }
    }

}
