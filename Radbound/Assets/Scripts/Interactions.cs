using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interactions : MonoBehaviour
{
    PlayerStats stats;
    

    //Sleep Stuffs
    //public GameObject SleepPanel;
    public PlayerController playerController;
    public float sleepCount = 5f;

 
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        //SleepPanel.SetActive(false);


        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sleep()
    {
        playerController.SleepPanel.SetActive(true);
        playerController.isMovementAllowed = false;

        StartCoroutine(SleepThroughNight());

      
    }
    private IEnumerator SleepThroughNight()
    {
        yield return new WaitForSeconds(sleepCount);
        playerController.SleepPanel.SetActive(false);
        playerController.isMovementAllowed = true;

        stats.TirednessPoints = stats.MaxTiredness;
        stats.CleanlinessPoints += 20f;
        stats.ThirstPoints -= 20f;
        stats.HungerPoints -= 30f;


    }



    public void Shower()
    {
        if (Input.GetKey(KeyCode.F))
        {
            
            StartCoroutine(Showering());
           
        }
        else
        {
            Debug.Log("TooClean");
        }
    }
    private IEnumerator Showering()
    {
        yield return new WaitForSeconds(4f);
        if (Input.GetKey(KeyCode.F))
        {
            stats.CleanlinessPoints += stats.MaxCleanliness / 2;
            stats.HungerPoints -= 15f;
            stats.TirednessPoints -= 20f;
            
        }
        


    }

    public void Eat()
    {
        stats.HungerPoints += 40f;
        stats.TirednessPoints -= 10f;
        stats.CleanlinessPoints -= 2f;

        
    }

    public void EatSmall()
    {
        stats.HungerPoints += 20f;
        stats.TirednessPoints -= 5f;
        stats.CleanlinessPoints -= 4f;


    }

    public void Drink()
    {
        stats.ThirstPoints += 40f;
        stats.TirednessPoints -= 5f;
        stats.CleanlinessPoints -= 2f;
        stats.HeatPoints -= 2f;

        
    }

    public void DrinkSmall()
    {
        stats.ThirstPoints += 20f;
        stats.TirednessPoints -= 3f;
        stats.CleanlinessPoints -= 4f;
        stats.HeatPoints -= 1f;


    }

    public void UseToilet()
    {
        if (Input.GetKey(KeyCode.F))
        {
            stats.CleanlinessPoints += stats.MaxCleanliness / 5;
            stats.HungerPoints -= 15f;
            stats.TirednessPoints -= 10f;
        }
    }

    public void UseSink()
    {
        if (Input.GetKey(KeyCode.F))
        {
            StartCoroutine(UsingSink());
        }

    }
    private IEnumerator UsingSink()
    {
        yield return new WaitForSeconds(2f);
        if (Input.GetKey(KeyCode.F))
        {
            stats.CleanlinessPoints += stats.MaxCleanliness/4;
            stats.HungerPoints -= 10f;
            stats.TirednessPoints -= 10f;
        }


        




        
    }

    public void PickUpAxe()
    {
        stats.HasAxe = true;

    }

    public void PickUpBucket()
    {
        stats.HasBucket = true;
    }

    public void PickUpPipe()
    {
        stats.HasPipe = true;
    }

    public void BurnWood()
    {
        if(stats.WoodCount > 0)
        {
            stats.WoodCount--;

            stats.HeatPoints += 10f;
        }
        else
        {
            Debug.Log("No Wood");
        }
        
    }

    public void FillPipe()
    {
        if (stats.HasBucket)
        {
            stats.HasBucket = false;
            stats.PipeFilled = true;
            Debug.Log("PipeFilled");
        }
        else
        {
            Debug.Log("No Bucket");
        }
    }
    public void PipeRepair()
    {
        stats.PipeFixed = true;
        Debug.Log("PipeFixed");
    }
   
    
   




}
