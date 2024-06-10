using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class TimeDisplay : MonoBehaviour
{
    public void DisplayTime(TextMeshProUGUI _timerText, Timer _timer)
    {
        float minutes = Mathf.FloorToInt(_timer.TimeRemaining / 60);
        float seconds = Mathf.FloorToInt(_timer.TimeRemaining % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (_timer.TimeRemaining < 10)
        {
            _timerText.color = Color.red;
        }
        else
        {
            _timerText.color = Color.white;
        }
    }
}
