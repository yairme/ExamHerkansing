using UnityEngine;

public class PickUp_DropManager : MonoBehaviour
{
    [SerializeField] private float Passengers = 0;
    [SerializeField] private float MaxPassengers = 0;
    [SerializeField] private PickUp_Drop[] DropPoints;
    [SerializeField] private PickUp_Drop PickUpPoint;
    public float TotalPassengers
    {
        get { return Passengers; }
        set { Passengers = value; }
    }
    public float TotalMaxPassengers
    {
        get { return MaxPassengers; }
    }
}