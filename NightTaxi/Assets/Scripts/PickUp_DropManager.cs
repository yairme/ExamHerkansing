using NUnit.Framework;
using UnityEngine;

public class PickUp_DropManager : MonoBehaviour
{
    [SerializeField] private int MaxPassengers = 0;
    [SerializeField] private GameObject[] DropPoints;
    [SerializeField] private PickUp_Drop PickUpPoint;
    private int ActiveDropPoints = 0;
    private int Passengers = 0;
    private bool IsPickup = false;
    private bool IsDropped = false;
    public int GetPassengers
    {
        get { return Passengers; }
    }
    public bool OnPickUpBool
    {
        get { return IsPickup; }
        set { IsPickup = value; }
    }
    public bool OnDropBool
    {
        get { return IsDropped; }
        set { IsDropped = value; }
    }
    private void Update()
    {
        if (PickUpPoint.IsItActive)
        {
            OnPickUp();
        }
        OnDrop();
    }
    private void OnPickUp()
    {
        if (Passengers < MaxPassengers)
        {
            Passengers = MaxPassengers;
            RandomDropSetActive();
            PickUpPoint.IsItActive = false;
            IsPickup = true;
        }
    }
    private void OnDrop()
    {
        foreach (GameObject dropPoint in DropPoints)
        {
            if (dropPoint.GetComponent<PickUp_Drop>().IsItActive == true)
            {
                if (Passengers > 0)
                {
                    Passengers--;
                    dropPoint.GetComponent<PickUp_Drop>().IsItActive = false;
                    dropPoint.SetActive(false);
                    IsDropped = true;
                }
            }
        }
    }
    private void RandomDropSetActive()
    {
        for (int i = 0; i < MaxPassengers; i++)
        {
            ActiveDropPointsCount();
            int randomDrop = Random.Range(0, DropPoints.Length);
            var chosenDropPoint = DropPoints[randomDrop];

            if (chosenDropPoint.activeSelf) continue;
            if (ActiveDropPoints == MaxPassengers) break;
            chosenDropPoint.SetActive(true);
        }
    }
    private void ActiveDropPointsCount()
    {
        for (int i = 0; i < DropPoints.Length; i++)
        {
            if (DropPoints[i].activeSelf)
            {
                ActiveDropPoints++;
            }
        }
    }
}