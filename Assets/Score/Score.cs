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
            this.score = data.score;
        }

        public void SaveData(ref GameData data)
        {
            data.score = this.score;
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + score;
        }
    }
}
