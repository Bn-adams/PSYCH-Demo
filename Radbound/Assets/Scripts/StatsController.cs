using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;
using static StatsController;

public class StatsController : MonoBehaviour
{
    public Image HealthBar;
    public Image ThirstBar;
    public Image HungerBar;
    public Image CleanlinessBar;
    public Image HeatBar;
    public Image TirednessBar;
    public Image MoodBar;

    //MoodFaces
    public GameObject Face1;
    public GameObject Face2;
    public GameObject Face3;
    public GameObject Face4;
    public GameObject Face5;


    public PlayerController PlayerController;

    private PlayerStats stats;
    



    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();


        //sets all the stats to there max count
        stats.HealthPoints = stats.MaxHealth;
        stats.ThirstPoints = 50f;
        stats.HungerPoints = 50f;
        stats.CleanlinessPoints = 60f;
        stats.HeatPoints = 20f;
        stats.TirednessPoints = 80f;
        stats.MoodPoints = 20f;

        Face1.SetActive(false);
        Face2.SetActive(false);
        Face3.SetActive(false);
        Face4.SetActive(false);
        Face5.SetActive(false);

    }

   
    
        
    private void FixedUpdate()
    {

        ThirstManager();
        HungerManager();
        CleanlinessManager();
        HeatManager();
        TirednessManager();
        MoodManager();
        

    }

    private void Update()
    {
        


    }
    void HealthManager()
    {
        if(stats.HealthPoints < stats.MinHealth) stats.HealthPoints = stats.MinHealth;

        HealthBar.fillAmount = stats.HealthPoints / stats.MaxHealth;
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
        //Debug.Log("Thirst Updated");

       


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
        //if (stats.MS > 16f)
        //{
        //    stats.CleanlinessPoints -= (stats.HungerBurn * 1.2f) * Time.deltaTime;
        //}
        //else
        //{
        //    stats.CleanlinessPoints -= stats.HungerBurn * Time.deltaTime;
        //}

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

        //Mood



    }

    void HeatManager()
    {
        if (PlayerController.isOutside)
        {
            stats.HeatPoints -= stats.OutDoorHeatBurn * Time.deltaTime;

            if (PlayerController.isStatic)
            {
                stats.HeatPoints += (stats.StaticHeatGen * 0.5f) * Time.deltaTime;

            }

            if (PlayerController.isRecharging)
            {
                stats.HeatPoints -= (stats.OutDoorHeatBurn * 1.5f) * Time.deltaTime;
            }

           
            if (stats.MS > 16f)
            {
                stats.HeatPoints += (stats.MovingHeatGen * 1.4f) * Time.deltaTime;
            }
            else 
            {
                if (!PlayerController.isStatic)
                {
                    stats.HeatPoints += stats.MovingHeatGen * Time.deltaTime;
                }
                
            }

         

           
            //Debug.Log("Outdoorburn");
        }
        else
        {
            stats.HeatPoints -= stats.InDoorHeatBurn * Time.deltaTime;

           
            if (PlayerController.isRecharging)
            {
                stats.HeatPoints -= (stats.InDoorHeatBurn * 1.5f) * Time.deltaTime;
            }

            if (stats.MS > 16f)
            {
                stats.HeatPoints += (stats.MovingHeatGen * 1.4f) * Time.deltaTime;
            }
            else
            {
                stats.HeatPoints += stats.MovingHeatGen * Time.deltaTime;
            }

           

        }

        if (stats.HeatPoints < stats.MinHeat) stats.HeatPoints = stats.MinHeat;

        HeatBar.fillAmount = stats.HeatPoints / stats.MaxHeat;

       

    }

    void TirednessManager()
    {
        stats.TirednessPoints -= stats.EnegryBurn * Time.deltaTime;

        if (stats.TirednessPoints < stats.MinTiredness) stats.TirednessPoints = stats.MinTiredness;

        TirednessBar.fillAmount = stats.TirednessPoints / stats.MaxTiredness;

    }

    void MoodManager()
    {

        MoodSetter();



        MoodBar.fillAmount = stats.MoodPoints / stats.MaxMood;

        //Mood Bar Icon states

        float moodpercentage = (stats.MoodPoints / stats.MaxMood) * 100f;

        if (moodpercentage < 20f)
        {
            HandleFaceState(FaceState.F1);

            PlayerController.chargeRate = 15 * 0.6f;
            stats.MaxStamina = 60f;

        }
        else if (moodpercentage < 40f)
        {
            HandleFaceState(FaceState.F2);

            PlayerController.chargeRate = 15 * 0.8f;
            stats.MaxStamina = 80f;
        }
        else if (moodpercentage < 60f)
        {
            HandleFaceState(FaceState.F3);

            PlayerController.chargeRate = 15f;
            stats.MaxStamina = 100f;
        }
        else if (moodpercentage < 60f)
        {
            HandleFaceState(FaceState.F4);

            PlayerController.chargeRate = 15 * 1.2f;
            stats.MaxStamina = 120f;
        }
        else
        {
            HandleFaceState(FaceState.F5);

            PlayerController.chargeRate = 15 * 1.4f;
            stats.MaxStamina = 140f;
        }
       

    }

    public enum FaceState
    {
        F1,
        F2,
        F3,
        F4,
        F5
    }
    void HandleFaceState(FaceState currentState)
    {
        switch(currentState)
        {
            case FaceState.F1:
                Face5.SetActive(true);

                Face1.SetActive(false);
                Face2.SetActive(false);
                Face3.SetActive(false);
                Face4.SetActive(false);
                
                break;

            case FaceState.F2:
                Face4.SetActive(true);

                Face1.SetActive(false);
                Face2.SetActive(false);
                Face3.SetActive(false);
                Face5.SetActive(false);

                break;

            case FaceState.F3:
                Face3.SetActive(true);

                Face1.SetActive(false);
                Face2.SetActive(false);
                Face4.SetActive(false);
                Face5.SetActive(false);

                break;

            case FaceState.F4:
                Face2.SetActive(true);

                Face1.SetActive(false);
                Face3.SetActive(false);
                Face4.SetActive(false);
                Face5.SetActive(false);

                break;

            case FaceState.F5:
                Face1.SetActive(true);

                Face2.SetActive(false);
                Face3.SetActive(false);
                Face4.SetActive(false);
                Face5.SetActive(false);

                break;
            
                
        }
    }

    void MoodSetter()
    {


        ////Thirst Section
        ///
        float thirstpercent = (stats.ThirstPoints / stats.MaxThirst) * 100f;

        if (thirstpercent < 20f)
        {
            stats.MoodPoints -= .2f * Time.deltaTime;
            Debug.Log("Thirst<20");
            stats.HealthPoints -= 0.5f * Time.deltaTime;
           

        }
        else if (thirstpercent < 40f)
        {
            
            stats.MoodPoints -= .1f * Time.deltaTime;
            Debug.Log("Thirst<40");
            
        }
        else if (thirstpercent < 60f)
        {
            stats.MoodPoints += 0.01f * Time.deltaTime;
            Debug.Log("Thirst<60");
        }
        else if (thirstpercent < 80f)
        {
            stats.MoodPoints += .1f * Time.deltaTime;
            Debug.Log("ThirstThirst<80");
        }
        else
        {
            stats.MoodPoints += .2f * Time.deltaTime;
            Debug.Log("Thirst80-100");

        }

        ////Hunger Section
        ///
        float hungerpercent = (stats.HungerPoints / stats.MaxHunger) * 100f;

        if (hungerpercent < 20f)
        {
            stats.MoodPoints -= .2f * Time.deltaTime;
            Debug.Log("Hunger<20");
            stats.HealthPoints -= 0.2f * Time.deltaTime;
        }
        else if (hungerpercent < 40f)
        {
            stats.MoodPoints -= .1f * Time.deltaTime;
            Debug.Log("Hunger<40");
        }
        else if (hungerpercent < 60f)
        {
            Debug.Log("Hunger<60");
            stats.MoodPoints += 0.01f * Time.deltaTime;
        }
        else if (hungerpercent < 80f)
        {

            stats.MoodPoints += .1f * Time.deltaTime;
            Debug.Log("Hunger<80");
        }
        else 
        {
            stats.MoodPoints += .2f * Time.deltaTime;
            Debug.Log("Hunger80-100");
        }

        ////Cleanliness Section
        ///
        float cleanlinesspercent = (stats.CleanlinessPoints / stats.MaxCleanliness) * 100f;

        if (cleanlinesspercent < 20f)
        {
            stats.MoodPoints -= .2f * Time.deltaTime;
            Debug.Log("cleanliness<20");
            stats.HealthPoints -= 0.01f * Time.deltaTime;
        }
        else if (cleanlinesspercent < 40f)
        {
            stats.MoodPoints -= .1f * Time.deltaTime;
            Debug.Log("cleanliness<40");
        }
        else if (cleanlinesspercent < 60f)
        {
            stats.MoodPoints += 0.01f * Time.deltaTime;
            Debug.Log("cleanliness<60");
        }
        else if (cleanlinesspercent < 80f)
        {
            stats.MoodPoints += .1f * Time.deltaTime;
            Debug.Log("cleanliness<80");
        }
        else
        {
            stats.MoodPoints += .2f * Time.deltaTime;
            Debug.Log("cleanliness80-100");
        }



        ////Heat Section
        ///
        float heatpercent = (stats.HeatPoints / stats.MaxHeat) * 100f;

        if (heatpercent <20f)
        {
            stats.MoodPoints -= .2f * Time.deltaTime;
            Debug.Log("heat<20");
            stats.HealthPoints -= 0.01f * Time.deltaTime;
           
        }
        else if (heatpercent < 20f)
        {
            Debug.Log("heat<40");
            stats.MoodPoints -= .1f * Time.deltaTime;
        }
        else if (heatpercent < 20f)
        {
            stats.MoodPoints += 0.01f * Time.deltaTime;
            Debug.Log("heat<60");
        }
        else if (heatpercent < 20f)
        {
            stats.MoodPoints += .1f * Time.deltaTime;
            Debug.Log("heat<80");
        }
        else
        {
            stats.MoodPoints += .2f * Time.deltaTime;
            Debug.Log("heat80-100");

        }

        ////Tiredness Section
        ///
        float tirednesspercent = (stats.TirednessPoints / stats.MaxTiredness) * 100f;


        if (tirednesspercent < 20f)
        {
            stats.MoodPoints -= .2f * Time.deltaTime;
            Debug.Log("tiredness<20");
            stats.HealthPoints -= 0.01f * Time.deltaTime;
        }
        else if (tirednesspercent < 40f)
        {
            stats.MoodPoints -= .1f * Time.deltaTime;
            Debug.Log("tiredness<40");
        }
        else if (tirednesspercent < 60f)
        {
            stats.MoodPoints += 0.01f * Time.deltaTime;
            Debug.Log("tiredness<60");
        }
        else if (tirednesspercent < 80f)
        {
            stats.MoodPoints += .1f * Time.deltaTime;
            Debug.Log("tiredness<80");
        }
        else
        {
            stats.MoodPoints += .2f * Time.deltaTime;
            Debug.Log("tiredness80-100");
        }

        HealthManager();

    }
    //public enum ThirstState
    //{
    //    Th1,
    //    Th2,
    //    Th3,
    //    Th4,
    //    Th5
    //}
    //void ThirstMoodState(ThirstState currentState)
    //{
    //    switch (currentState)
    //    {
    //        case ThirstState.Th1:
               
    //            break;

    //        case ThirstState.Th2:
               
    //            break;

    //        case ThirstState.Th3:
               
    //            break;

    //        case ThirstState.Th4:
                
    //            break;

    //        case ThirstState.Th5:
                
    //            break;


    //    }
    //}
    //public enum HungerState
    //{
    //    H1,
    //    H2,
    //    H3,
    //    H4,
    //    H5
    //}
    //void HungerMoodState(HungerState currentState)
    //{
    //    switch (currentState)
    //    {
    //        case HungerState.H1:
    //            break;

    //        case HungerState.H2:

    //            break;

    //        case HungerState.H3:

    //            break;

    //        case HungerState.H4:

    //            break;

    //        case HungerState.H5:

    //            break;


    //    }
    //}
    //public enum CleanlinessState
    //{
    //    C1,
    //    C2,
    //    C3,
    //    C4,
    //    C5
    //}
    //void CleanlinessMoodState(CleanlinessState currentState)
    //{
    //    switch (currentState)
    //    {
    //        case CleanlinessState.C1:
    //            break;

    //        case CleanlinessState.C2:

    //            break;

    //        case CleanlinessState.C3:

    //            break;

    //        case CleanlinessState.C4:

    //            break;

    //        case CleanlinessState.C5:

    //            break;


    //    }
    //}
    //public enum HeatState
    //{
    //    C1,
    //    C2,
    //    C3,
    //    C4,
    //    C5
    //}
    //void HeatMoodState(HeatState currentState)
    //{
    //    switch (currentState)
    //    {
    //        case HeatState.C1:
    //            break;

    //        case HeatState.C2:

    //            break;

    //        case HeatState.C3:

    //            break;

    //        case HeatState.C4:

    //            break;

    //        case HeatState.C5:

    //            break;


    //    }
    //}

    //public enum TirednessState
    //{
    //    T1,
    //    T2,
    //    T3,
    //    T4,
    //    T5
    //}
    //void TirednessMoodState(TirednessState currentState)
    //{
    //    switch (currentState)
    //    {
    //        case TirednessState.T1:
    //            stats.MoodPoints -= .2f * Time.deltaTime;

    //            break;

    //        case TirednessState.T2:
    //            stats.MoodPoints -= .1f * Time.deltaTime;
    //            break;

    //        case TirednessState.T3:
    //            stats.MoodPoints += .001f * Time.deltaTime;
    //            break;

    //        case TirednessState.T4:
    //            stats.MoodPoints += .1f * Time.deltaTime;
    //            break;

    //        case TirednessState.T5:
    //            stats.MoodPoints += .2f * Time.deltaTime;
    //            break;


    //    }
   

    //}

}
