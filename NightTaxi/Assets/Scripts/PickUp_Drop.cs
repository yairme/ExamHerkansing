using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NUnit.Framework;

public class PickUp_Drop : MonoBehaviour
{
    [SerializeField] private UnityEvent Trigger;
    private bool IsActive = false;
    public bool IsItActive
    {
        get { return IsActive; }
        set { IsActive = value; }
    }
    private void Start() {
        Trigger = new UnityEvent();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger.Invoke();
            IsActive = true;
        }
    }
}
