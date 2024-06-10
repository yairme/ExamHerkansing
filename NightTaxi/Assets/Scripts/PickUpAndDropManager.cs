using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PickUpAndDropManager : MonoBehaviour
{
    [SerializeField] private int MaxPassengers;
    [SerializeField] private int AddScore;
    [SerializeField] private Vector3 ParticleOffset;
    [SerializeField] private GameObject PickUpEffect;
    [SerializeField] private GameObject DropEffect;
    [SerializeField] private UnityEvent OnDropEvent;
    [SerializeField] private UnityEvent OnPickUpEvent;
    private int ActiveDropPointCount = 0;
    private int Passengers = 0;
    private int Score = 0;
    private GameObject PickUpPoint;
    private GameObject[] DropPoints;
    private GameObject[] ActiveDropPoints;
    private MeshRenderer PickUpRenderer;
    public int getPassengers
    {
        get => Passengers; 
        set => Passengers = value;
    }

    public int getScore
    {
        get => Score; 
        set => Score = value;
    }

    private void Awake()
    {  
        DropPoints = GameObject.FindGameObjectsWithTag("Drop"); //FindGameObjectsWithTag is used to find all objects with the tag "Drop" so you don't have to assign them manually
        PickUpPoint = GameObject.FindGameObjectWithTag("PickUp"); //FindGameObjectWithTag is used to find the object with the tag "PickUp" so you don't have to assign it manually
    }

    private void Start()
    {   
        SetupDropPoints(); //This method is called to set up the drop points
        SetupPickUpPoint(); //This method is called to set up the pick up point
    }

    public void ResetScore()
    {
        Passengers = 0;
        Score = 0;
        ActiveDropPointCount = 0;
        for (int i = 0; i < DropPoints.Length; i++)
        {
            DropPoints[i].GetComponent<PickUpAndDrop>().isItActive = false;
            DropPoints[i].SetActive(false);
        }
        PickUpPoint.GetComponent<PickUpAndDrop>().isItActive = false;
    }

    public void OnPickUp()
    {
        if (Passengers < MaxPassengers)
        {
            Passengers = MaxPassengers;
            RandomDropSetActive();
            PickUpPoint.GetComponentInChildren<ParticleSystem>().Stop();
            if (PickUpPoint.GetComponentInChildren<ParticleSystem>().gameObject.tag == "OnPickUpParticle") //Check if the particle system has the tag "PickUpEffect"
            {
                PickUpPoint.GetComponentInChildren<ParticleSystem>().Play();
            }
            PickUpPoint.GetComponent<PickUpAndDrop>().isItActive = true;
        }
    }

    public void OnDrop()
    {
        StartCoroutine(EnumeratorOnDrop());
    }

    private IEnumerator EnumeratorOnDrop()
    {
        Passengers--;
        ActiveDropPointCount--;
        Score += AddScore;
        PickUpPoint.GetComponent<PickUpAndDrop>().isItActive = false;
        if (PickUpPoint.GetComponentInChildren<ParticleSystem>().gameObject.tag == "PickUpHighlight" && !PickUpPoint.GetComponent<PickUpAndDrop>().isItActive) //Check if the particle system has the tag "PickUpEffect"
        {
            PickUpPoint.GetComponentInChildren<ParticleSystem>().Play();
        }
        for (int i = 0; i < DropPoints.Length; i++)
        {
            for (int j = 0; j < ActiveDropPoints.Length; j++)
            {
                if (ActiveDropPoints[j] == DropPoints[i] && ActiveDropPoints[j].GetComponent<PickUpAndDrop>().isItActive)
                {
                    DropPoints[i].GetComponent<PickUpAndDrop>().isItActive = false;
                    DropPoints[i].GetComponentInChildren<ParticleSystem>().Stop();
                    if (DropPoints[i].GetComponentInChildren<ParticleSystem>().gameObject.tag == "OnDropParticle") //Check if the particle system has the tag "DropEffect"
                    {
                        DropPoints[i].GetComponentInChildren<ParticleSystem>().Play();
                        yield return new WaitForSeconds(DropPoints[i].GetComponentInChildren<ParticleSystem>().main.duration);
                    }
                    DropPoints[i].SetActive(false);
                    ActiveDropPoints[j] = null;
                    break;
                }
            }
        }
    }

    private void SetupDropPoints()
    {
        foreach (GameObject dropPoint in DropPoints)
        {
            dropPoint.GetComponent<PickUpAndDrop>().setTrigger = OnDropEvent;
            Instantiate(DropEffect, dropPoint.transform.position + ParticleOffset, Quaternion.identity, dropPoint.transform);
            dropPoint.GetComponentInChildren<ParticleSystem>().Stop();
            dropPoint.SetActive(false);
        }
        ActiveDropPoints = new GameObject[MaxPassengers];
    }

    private void SetupPickUpPoint()
    {
        PickUpPoint.GetComponent<PickUpAndDrop>().setTrigger = OnPickUpEvent;
        Instantiate(PickUpEffect, PickUpPoint.transform.position + ParticleOffset, Quaternion.identity, PickUpPoint.transform);
        PickUpPoint.GetComponentInChildren<ParticleSystem>().Stop();
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
                if (DropPoints[randomIndex].GetComponentInChildren<ParticleSystem>().gameObject.tag == "DropHighlight") //Check if the particle system has the tag "PickUpEffect"
                {
                    DropPoints[randomIndex].GetComponentInChildren<ParticleSystem>().Play();
                }
                ActiveDropPointCount++;
            }
        }
    }
}