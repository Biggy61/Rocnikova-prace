using System;
using UnityEngine;

public class Health : MonoBehaviour
{
   public GameObject heart1;
   public GameObject heart2;
   public GameObject heart3;
   public GameObject heart4;
   public GameObject heart5;
   public GameObject player;
   public int hp;
   public void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player");
   }

   public void Update()
   {
      hp = player.GetComponent<Player>().hp;
      SetHealth(10, heart1);
      SetHealth(30, heart2);
      SetHealth(50, heart3);
      SetHealth(70, heart4);
      SetHealth(90, heart5);
   }

   public void SetHealth(int health, GameObject heart)
   {
      if (hp < health)
      {
         heart.SetActive(false);
      }
      else
      {
         heart.SetActive(true);
      }
   }
  
}
