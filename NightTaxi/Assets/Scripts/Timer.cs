using UnityEngine;
using UnityEngine.Serialization;


public class Timer : MonoBehaviour
{
    [SerializeField] private float timerDuration;
    [SerializeField] private float addedTime;
    private float thisTimeRemaining;
    private bool timerIsRunning;

    public float TimeRemaining
    {
        get => thisTimeRemaining; 
    }

    public bool IsTimerRunning
    {
        get => timerIsRunning;
    }
    
    public void StartTimer()
    { 
        thisTimeRemaining = timerDuration;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (thisTimeRemaining > 0)
            {
                thisTimeRemaining -= Time.deltaTime;
            }
            else
            {
                thisTimeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void AddTime()
    {
        thisTimeRemaining += addedTime;
        if (thisTimeRemaining > 0 && !timerIsRunning)
        {
            timerIsRunning = true;
        }
    }
}