using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Drop : MonoBehaviour
{
    private bool IsActive = false;
    public bool IsItActive
    {
        get { return IsActive; }
        set { IsActive = value; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsActive = true;
        }
    }
}
