using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NUnit.Framework;

public class PickUp_Drop : MonoBehaviour
{
    [SerializeField] private GameObject PopUp;
    [SerializeField] private UnityEvent Trigger;
    private bool IsActive = false;
    public bool IsItActive
    {
        get { return IsActive; }
        set { IsActive = value; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !IsActive)
        {
            Trigger.Invoke();
            IsActive = true;
            OnTriggerPopUp();
        }
    }
    private void OnTriggerPopUp()
    {
        var _internalTimer = 5f;
        _internalTimer -= Time.deltaTime;
        PopUp.SetActive(true);
        if (_internalTimer <= 0)
        {
            PopUp.SetActive(false);
        }
    }
}
