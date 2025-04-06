using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class Heal : MonoBehaviour, DataPersistance
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid of ID")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    public GameObject player;
    public GameObject score;

    public bool collected= false;
    // Start is called before the first frame update
    public void LoadData(GameData data)
    {
        Debug.Log("blablabla");
        bool isCollected;
      data.healsCollected.TryGetValue(id, out isCollected);
      Debug.Log(id + isCollected);
      if (isCollected)
      {
         this.gameObject.SetActive(false);
      }
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("saving ");
        //pokud uz je v Dictionary tam se vymaze a prida znovu
        if (data.healsCollected.ContainsKey(id))
        {
            data.healsCollected.Remove(id);
        }   
        data.healsCollected.Add(id, collected);
        Debug.Log(id + collected);
    }
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            collected = true;
            Debug.Log(collected);
            score.GetComponent<Score.Score>().score += 10;
            if (player.GetComponent<Player>().hp < 100)
            {
                player.GetComponent<Player>().hp += 10;
                Debug.Log("Healed");
            }

            
            
        }


    }
}
