using UnityEngine.Events;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
    private bool IsActive;
    private UnityEvent Trigger;
    
    public bool isItActive
    {
        get => IsActive; 
        set => IsActive = value; 
    }
    
    public UnityEvent setTrigger
    {
        get => Trigger;
        set => Trigger = value;
    }

    private void Start()
    {
        IsActive = false;
    }

    private void OnTriggerEnter(Collider other) //Player Object needs Rigidbody and Collider
    {
        if (other.tag == "Player" && !IsActive)
        {
            IsActive = true;
            Trigger.Invoke();
        }
    }
}
