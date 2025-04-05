using UnityEngine;

[System.Serializable]
public class GameData
{
    public float score;
    public Vector3 playerPosition;
    public GameData()
    {
        this.score = 0;
        playerPosition = Vector3.zero;
    }
}
