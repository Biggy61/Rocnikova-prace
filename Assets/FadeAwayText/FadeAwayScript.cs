using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAwayScript : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float fadeAwayTime = 3f;
    private int currentLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        text.text = "Level: " +  currentLevel.ToString();
        FadeAway();
    }

    public void FadeAway()
    {
        if (fadeAwayTime > 0)
        {
            fadeAwayTime -= Time.deltaTime;
            
            text.color = new Color(text.color.r, text.color.g, text.color.b,  fadeAwayTime);
        }
    }
}
