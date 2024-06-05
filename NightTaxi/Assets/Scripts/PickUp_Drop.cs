using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NUnit.Framework;
using Unity.VisualScripting;

public class PickUp_Drop : MonoBehaviour
{
    private UnityEvent Trigger;
    private bool IsActive;
    public bool IsItActive
    {
        get => IsActive; 
        set => IsActive = value; 
    }
    public UnityEvent SetTrigger
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
