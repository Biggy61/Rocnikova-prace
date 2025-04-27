using TMPro;
using UnityEngine;

public class TimeElapsed : MonoBehaviour, DataPersistance
{
    public int minutes;
    public int seconds;
    public float milliseconds;
    public TextMeshProUGUI timeElapsedText;
    public float timer; 
    
    public void LoadData(GameData data)
    {
      this.minutes = data.minutes;
      this.seconds = data.seconds;
      this.milliseconds = data.milliseconds;
    }

    public void SaveData(ref GameData data)
    {
      data.minutes = this.minutes;
      data.seconds = this.seconds;
      data.milliseconds = this.milliseconds;
    }
    void Update()
    {
        string niceTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        timer += Time.deltaTime;
        milliseconds += Time.deltaTime * 1000f;
        if (timer >= 1)
        {
            seconds++;
            timer = 0;
        }

        if (milliseconds >= 1000f)
        {
            milliseconds = 0; 
        }
        if (seconds >= 60)
           {
             minutes++;
             seconds = 0;
           }
        
        timeElapsedText.text = "Time elapsed: " + niceTime; 
    }
}
