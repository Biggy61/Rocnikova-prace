using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float score;
    public Vector3 playerPosition;
    public int playerHp;
    public SerializableDictionary<string, bool> healsCollected;
    public SerializableDictionary<string, bool> enemiesKilled;
    public GameData()
    {
        this.score = 0;
        playerPosition = Vector3.zero;
        playerHp = 100;
        healsCollected = new SerializableDictionary<string, bool>();
        enemiesKilled = new SerializableDictionary<string, bool>();
    }
}
