using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAwayTextScript : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float fadeAwayTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "YOU WIN!";
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
