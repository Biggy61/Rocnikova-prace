using TMPro;
using UnityEngine;

public class FadeAwayScript : MonoBehaviour
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
