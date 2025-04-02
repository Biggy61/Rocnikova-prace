using TMPro;
using UnityEngine;

namespace Score
{
    public class Score : MonoBehaviour, DataPersistance
    {
        public float score;
        public TextMeshProUGUI scoreText;

        public void LoadData(GameData data)
        {
            score = data.Score;
        }

        public void SaveData(ref GameData data)
        {
            data.Score = score;
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + score;
        }
    }
}
