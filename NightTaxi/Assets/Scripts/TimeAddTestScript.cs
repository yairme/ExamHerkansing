using UnityEngine;

public class TimeAdder : MonoBehaviour
{
    public Timer Timer;
    public float TimeToAdd = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Timer.AddTime(TimeToAdd);
        }
    }
}