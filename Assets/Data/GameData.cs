using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float score;
    public int minutes;
    public int seconds;
    public Vector3 playerPosition;
    public Vector3 movingPlatformPosition;
    public int playerHp;
    public SerializableDictionary<string, bool> healsCollected;
    public SerializableDictionary<string, bool> enemiesKilled;

    public GameData()
    {
        movingPlatformPosition = new Vector3(1020, 40, 160);
        this.minutes = 0;
        this.seconds = 0;
        this.score = 0;
        playerPosition = Vector3.zero;
        playerHp = 100;
        healsCollected = new SerializableDictionary<string, bool>();
        enemiesKilled = new SerializableDictionary<string, bool>();
    }
}