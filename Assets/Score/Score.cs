using TMPro;
using UnityEngine;

namespace Score
{
    public class Score : MonoBehaviour
    {
        public float score;
        public TextMeshProUGUI scoreText;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + score;
        }
    }
}
