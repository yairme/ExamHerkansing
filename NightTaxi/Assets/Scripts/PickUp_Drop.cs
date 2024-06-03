using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Drop : MonoBehaviour
{
    [SerializeField] private PickUp_DropManager Manager;
    private bool isActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("PickUp"))
        {
            if (Manager.TotalPassengers < Manager.TotalMaxPassengers)
            {
                Manager.TotalPassengers = Manager.TotalMaxPassengers;
            }
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Drop"))
        {
            if (Manager.TotalPassengers > 0)
            {
                Manager.TotalPassengers -= 1;
            }
        }
    }
}
