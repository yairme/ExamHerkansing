using UnityEngine;

public class PickUp_DropManager : MonoBehaviour
{
    [SerializeField] private int MaxPassengers;
    [SerializeField] private int AddScore;
    [SerializeField] private GameObject PickUpPoint;
    [SerializeField] private GameObject[] DropPoints;
    private GameObject[] ActiveDropPoints;
    private int ActiveDropPointCount = 0;
    private int Passengers = 0;
    private int Score = 0;
    public int GetPassengers
    {
        get => Passengers; 
    }
    public int GetScore
    {
        get => Score; 
    }
    private void Start()
    {
        foreach (GameObject dropPoint in DropPoints)
        {
            dropPoint.SetActive(false);
        }
        ActiveDropPoints = new GameObject[MaxPassengers];
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
        Passengers--;
        ActiveDropPointCount--;
        Score += AddScore;
        PickUpPoint.GetComponent<PickUp_Drop>().IsItActive = false;
        for (int i = 0; i < DropPoints.Length; i++)
        {
            for (int j = 0; j < ActiveDropPoints.Length; j++)
            {
                if (ActiveDropPoints[j] == DropPoints[i] && ActiveDropPoints[j].GetComponent<PickUp_Drop>().IsItActive)
                {
                    DropPoints[i].GetComponent<PickUp_Drop>().IsItActive = false;
                    DropPoints[i].SetActive(false);
                    ActiveDropPoints[j] = null;
                    break;
                }
            }
        }
    }
    private void RandomDropSetActive()
    {
        for (int i = 0; i < MaxPassengers; i++)
        {
            if (ActiveDropPointCount == MaxPassengers) break;
            int randomIndex = Random.Range(0, DropPoints.Length);
            if (DropPoints[randomIndex].activeSelf && DropPoints[randomIndex]) i--;
            else
            {
                if (ActiveDropPoints[i] != null) continue;//This line is added to prevent null reference exception (IndexOutOfRangeException
                ActiveDropPoints[i] = DropPoints[randomIndex];
                DropPoints[randomIndex].SetActive(true);
                ActiveDropPointCount++;
            }
        }
    }
}