using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public Image ThirstBar;
    public Image HungerBar;
    public Image CleanlinessBar;
    public Image HeatBar;
    public Image MoodBar;

    public PlayerController PlayerController;

    private PlayerStats stats;
    private GameObject Player;



    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        Player = GameObject.Find("Player");

        //sets all the stats to there max count
        stats.ThirstPoints = stats.MaxThirst;
        stats.HungerPoints = stats.MaxHunger;
        stats.CleanlinessPoints = stats.MaxCleanliness;
        stats.HeatPoints = 20f;
        stats.MoodPoints = 20f;



    }

   
    
        
    private void FixedUpdate()
    {
        ThirstManager();
        HungerManager();
        CleanlinessManager();
        HeatManager(); 
        MoodManager();

    }

    private void Update()
    {
        


    }

    void ThirstManager()
    {
       
        if (stats.MS > 16f)
        {
            stats.ThirstPoints -= (stats.ThirstBurn * 1.2f) * Time.deltaTime;

        }
        else
        {
            stats.ThirstPoints -= stats.ThirstBurn * Time.deltaTime;
        }

        if (stats.ThirstPoints < stats.MinThirst) stats.ThirstPoints = stats.MinThirst;

        ThirstBar.fillAmount = stats.ThirstPoints / stats.MaxThirst;
        Debug.Log("Thirst Updated");
    }

    void HungerManager()
    {
        if (stats.MS > 16f)
        {
            stats.HungerPoints -= (stats.HungerBurn * 1.2f) * Time.deltaTime;
        }
        else
        {
            stats.HungerPoints -= stats.HungerBurn * Time.deltaTime;
        }

        if (PlayerController.isRecharging)
        {
            stats.HungerPoints -= (stats.HungerBurn * 2f) * Time.deltaTime;
        }

        if (stats.HungerPoints < stats.MinHunger) stats.HungerPoints = stats.MinHunger;

        HungerBar.fillAmount = stats.HungerPoints / stats.MaxHunger;

    }

    void CleanlinessManager()
    {
        if (stats.MS > 16f)
        {
            stats.CleanlinessPoints -= (stats.HungerBurn * 1.2f) * Time.deltaTime;
        }
        else
        {
            stats.CleanlinessPoints -= stats.HungerBurn * Time.deltaTime;
        }

        if (PlayerController.isOutside)
        {
            if (stats.MS > 16f)
            {
                stats.CleanlinessPoints -= (stats.OutDoorCleanBurn * 1.2f) * Time.deltaTime;
            }
            else
            {
                stats.CleanlinessPoints -= stats.OutDoorCleanBurn * Time.deltaTime;
            }
        }
        else
        {
            if (stats.MS > 16f)
            {
                stats.CleanlinessPoints -= (stats.InDoorCleanBurn * 1.2f) * Time.deltaTime;
            }
            else
            {
                stats.CleanlinessPoints -= stats.InDoorCleanBurn * Time.deltaTime;
            }
            
        }

        if (stats.CleanlinessPoints < stats.MinCleanliness) stats.CleanlinessPoints = stats.MinCleanliness;

        CleanlinessBar.fillAmount = stats.CleanlinessPoints / stats.MaxCleanliness;

    }

    void HeatManager()
    {
        if (PlayerController.isOutside)
        {
            stats.HeatPoints -= stats.OutDoorHeatBurn * Time.deltaTime;

            if (PlayerController.isStatic)
            {
                stats.HeatPoints += stats.StaticHeatGen * Time.deltaTime;
            }

            if (PlayerController.isRecharging)
            {
                stats.HeatPoints -= (stats.OutDoorHeatBurn * 2f) * Time.deltaTime;
            }

           
            if (stats.MS > 16f)
            {
                stats.HeatPoints += (stats.MovingHeatGen * 1.3f) * Time.deltaTime;
            }
            else
            {
                stats.HeatPoints += stats.MovingHeatGen * Time.deltaTime;
            }

         

           
            //Debug.Log("Outdoorburn");
        }
        else
        {
            stats.HeatPoints -= stats.InDoorHeatBurn * Time.deltaTime;

           
            if (PlayerController.isRecharging)
            {
                stats.HeatPoints -= (stats.InDoorHeatBurn * 2f) * Time.deltaTime;
            }

            if (stats.MS > 16f)
            {
                stats.HeatPoints += (stats.MovingHeatGen * 1.3f) * Time.deltaTime;
            }
            else
            {
                stats.HeatPoints += stats.MovingHeatGen * Time.deltaTime;
            }

           

        }

       

        HeatBar.fillAmount = stats.HeatPoints / stats.MaxHeat;

        stats.HeatPoints += stats.MovingHeatGen * Time.deltaTime;

    }

    void MoodManager()
    {

        MoodBar.fillAmount = stats.MoodPoints / stats.MaxMood;

    }


}
