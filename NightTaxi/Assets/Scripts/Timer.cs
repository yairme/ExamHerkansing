using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private float TimerDuration;
    [SerializeField] private float AddedTime;
    private float TimeRemaining;
    private bool TimerIsRunning = false;

    public GameObject gameOverPanel;

    void Start()
    { 
        TimeRemaining = TimerDuration;
        TimerIsRunning = true;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (TimerIsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                DisplayTime(TimeRemaining);
            }
            else
            {
                TimeRemaining = 0;
                TimerIsRunning = false;
                DisplayTime(TimeRemaining);
                GameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (TimeRemaining < 10)
        {
            TimerText.color = Color.red;
        }
        else
        {
            TimerText.color = Color.white;
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void AddTime()
    {
        TimeRemaining += AddedTime;
        if (TimeRemaining > 0 && !TimerIsRunning)
        {
            TimerIsRunning = true;
        }
        DisplayTime(TimeRemaining);
    }
}