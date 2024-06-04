using NUnit.Framework;
using UnityEngine;

public class PickUp_DropManager : MonoBehaviour
{
    [SerializeField] private int MaxPassengers = 0;
    [SerializeField] private int AddScore = 0;
    [SerializeField] private GameObject PickUpPoint;
    [SerializeField] private GameObject[] DropPoints;
    private int ActiveDropPoints = 0;
    private int Passengers = 0;
    private int Score = 0;
    public int GetPassengers
    {
        get { return Passengers; }
    }
    public int GetScore
    {
        get { return Score; }
    }
    public void OnPickUp()
    {
        if (Passengers < MaxPassengers)
        {
            Passengers = MaxPassengers;
            RandomDropSetActive();
            PickUpPoint.GetComponent<PickUp_Drop>().IsItActive = true;
        }
    }
    public void OnDrop()
    {
        foreach (GameObject dropPoint in DropPoints)
        {
            if (!dropPoint.activeSelf && dropPoint.GetComponent<PickUp_Drop>().IsItActive == false) { continue; }
            if (Passengers > 0)
            {
                Passengers--;
                ActiveDropPoints--;
                Score += AddScore;
                PickUpPoint.GetComponent<PickUp_Drop>().IsItActive = false;
                dropPoint.GetComponent<PickUp_Drop>().IsItActive = true;
                dropPoint.SetActive(false);
            }
        }
    }
    private void RandomDropSetActive()
    {
        foreach (GameObject dropPoint in DropPoints)
        {
            int randomDrop = Random.Range(0, DropPoints.Length);
            var chosenDropPoint = DropPoints[randomDrop];
            Debug.Log(randomDrop + " was chosen from " + DropPoints.Length + " drop points and it is " + chosenDropPoint.name + ".");

            if (chosenDropPoint.activeSelf) { Debug.Log("Continue"); continue;}
            if (ActiveDropPoints == MaxPassengers) { Debug.Log("Break"); break;}
            ActiveDropPointsCount();
            chosenDropPoint.SetActive(true);
        }
    }
    private void ActiveDropPointsCount()
    {
        for (int i = 0; i < DropPoints.Length; i++)
        {
            Debug.Log(DropPoints[i].name + " Were checked.");
            if (DropPoints[i].activeSelf)
            {
                Debug.Log(DropPoints[i].name + " is active.");
                ActiveDropPoints++;
            }
        }
    }


    public void Test()
    {
        Debug.Log($"Player has {GetPassengers} passengers and {GetScore} score, and there are {ActiveDropPoints} active drop points.");
    }
}