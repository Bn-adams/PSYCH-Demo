using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interactions : MonoBehaviour
{
    PlayerStats stats;
    

    //Sleep Stuffs
    public GameObject SleepPanel;
    public PlayerController playerController;
    public float sleepCount = 5f;

    //Axe Stuffs 
    public GameObject AxeHolder;
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        SleepPanel.SetActive(false);


        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sleep()
    {
        SleepPanel.SetActive(true);
        playerController.isMovementAllowed = false;

        StartCoroutine(SleepThroughNight());

      
    }
    private IEnumerator SleepThroughNight()
    {
        yield return new WaitForSeconds(sleepCount);
        SleepPanel.SetActive(false);
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
            stats.CleanlinessPoints += stats.MaxCleanliness / 4;
            stats.HungerPoints -= 10f;
            stats.TirednessPoints -= 10f;
            
        }
        


    }

    public void Eat()
    {
        stats.HungerPoints += 40f;
        stats.TirednessPoints -= 10f;
        stats.CleanlinessPoints -= 10f;

        
    }

    public void EatSmall()
    {
        stats.HungerPoints += 20f;
        stats.TirednessPoints -= 5f;
        stats.CleanlinessPoints -= 5f;


    }

    public void Drink()
    {
        stats.ThirstPoints += 40f;
        stats.TirednessPoints -= 5f;
        stats.CleanlinessPoints -= 5f;
        stats.HeatPoints -= 5f;

        
    }

    public void UseToilet()
    {
        if (Input.GetKey(KeyCode.F))
        {
            stats.CleanlinessPoints += stats.MaxCleanliness / 4;
            stats.HungerPoints -= 10f;
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
        AxeHolder.SetActive(true);

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
   
    

   




}
