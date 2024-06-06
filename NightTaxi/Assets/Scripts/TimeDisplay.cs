using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private Timer timer;
    
    public void DisplayTime(TextMeshProUGUI TimerText)
    {
        float minutes = Mathf.FloorToInt(timer.TimeRemaining / 60);
        float seconds = Mathf.FloorToInt(timer.TimeRemaining % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (timer.TimeRemaining < 10)
        {
            TimerText.color = Color.red;
        }
        else
        {
            TimerText.color = Color.white;
        }
    }
}
