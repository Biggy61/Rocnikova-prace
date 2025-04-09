using TMPro;
using UnityEngine;

public class TimeElapsed : MonoBehaviour, DataPersistance
{
    public int minutes;
    public int seconds;
    public TextMeshProUGUI timeElapsedText;
    public float timer; 
    
    public void LoadData(GameData data)
    {
      this.minutes = data.minutes;
      this.seconds = data.seconds;
    }

    public void SaveData(ref GameData data)
    {
      data.minutes = this.minutes;
      data.seconds = this.seconds;
    }
    void Update()
    {
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            seconds++;
            timer = 0;
        }

        if (seconds >= 60)
           {
             minutes++;
             seconds = 0;
           }
        
        timeElapsedText.text = "Time elapsed: " + niceTime; 
    }
}
