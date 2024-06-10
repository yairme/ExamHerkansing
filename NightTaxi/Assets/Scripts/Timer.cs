using UnityEngine;
using UnityEngine.Serialization;


public class Timer : MonoBehaviour
{
    [SerializeField] private float timerDuration;
    [SerializeField] private float addedTime;
    private float thisTimeRemaining;
    public float TimeRemaining
    {
        get => thisTimeRemaining; 
        set => thisTimeRemaining = value;
    }
    private void Awake()
    { 
        thisTimeRemaining = timerDuration;
    }

    void Update()
    {
        if (thisTimeRemaining > 0)
        {
            thisTimeRemaining -= Time.deltaTime;
        }
        else
        {
            thisTimeRemaining = 0;
        }
    }

    public void AddTime()
    {
        thisTimeRemaining += addedTime;
    }
}