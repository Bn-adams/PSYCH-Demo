using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class CorrelationChecker : MonoBehaviour
{
    PlayerStats stats;

    float lastHeatPoint;
    float lastThirstPoint;
    float lastHungerPoint;
    float lastCleanlinessPoint;
    float lastMoodPoint;
    float lastTirednessPoint;

    

    public Image Thirst1;
    public Image Thirst2;

    public Image Hunger1;
    public Image Hunger2;

    public Image Cleanliness1;
    public Image Cleanliness2;

    public Image Heat1;
    public Image Heat2;

    public Image Tiredness1;
    public Image Tiredness2;

    public Image Mood1;
    public Image Mood2;

    public bool showArrows = true;
   
    // Start is called before the first frame update
    void Start()
    {

        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

        

        Thirst1.gameObject.SetActive(false);
        Thirst2.gameObject.SetActive(false);

        Hunger1.gameObject.SetActive(false);
        Hunger2.gameObject.SetActive(false);

        Cleanliness1.gameObject.SetActive(false);
        Cleanliness2.gameObject.SetActive(false);

        Heat1.gameObject.SetActive(false);
        Heat2.gameObject.SetActive(false);

        Tiredness1.gameObject.SetActive(false);
        Tiredness2.gameObject.SetActive(false);

        Mood1.gameObject.SetActive(false);
        Mood2.gameObject.SetActive(false);

        StartCoroutine(StatCheckLoop());

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Alpha0))
        {
            showArrows = true;
        }

        if (Input.GetKey(KeyCode.Alpha9))
        {
            showArrows = false;
        }
            
       

        //if (showArrows)
        //{
        //    ThirstChecker();
        //    HungerChecker();
        //    CleanlinessChecker();
        //    HeatChecker();
        //    TirednessChecker();
        //    MoodChecker();


        //    lastThirstPoint = stats.ThirstPoints;
        //    lastHungerPoint = stats.HungerPoints;
        //    lastCleanlinessPoint = stats.CleanlinessPoints;
        //    lastHeatPoint = stats.HeatPoints;
        //    lastTirednessPoint = stats.TirednessPoints;
        //    lastMoodPoint = stats.MoodPoints;
        //}
        //else
        //{

        //}




    }
    IEnumerator StatCheckLoop()
    {
        while (true)
        {
            if (showArrows)
            {
                ThirstChecker();
                HungerChecker();
                CleanlinessChecker();
                HeatChecker();
                TirednessChecker();
                MoodChecker();


                lastThirstPoint = stats.ThirstPoints;
                lastHungerPoint = stats.HungerPoints;
                lastCleanlinessPoint = stats.CleanlinessPoints;
                lastHeatPoint = stats.HeatPoints;
                lastTirednessPoint = stats.TirednessPoints;
                lastMoodPoint = stats.MoodPoints;

            }
            yield return new WaitForSeconds(1f); // wait 1 second
        }
    }





        void ThirstChecker()
    {

        //Debug.Log(currentValue);
        //Debug.Log(lastValue);

        if (stats.ThirstPoints > lastThirstPoint)
        {
            Debug.Log("ThirstIsIncreasing");

            Thirst1.gameObject.SetActive(true);
            Thirst2.gameObject.SetActive(false);

            
        }
        else if (stats.ThirstPoints < lastThirstPoint) 
        {
            Debug.Log("ThirstIsDecreasing");

            Thirst1.gameObject.SetActive(false);
            Thirst2.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("ThirstStayedTheSame");

            Thirst1.gameObject.SetActive(false);
            Thirst2.gameObject.SetActive(false);
        }
        lastThirstPoint = stats.ThirstPoints;
    }

    

    void HungerChecker()
    {

        //Debug.Log(currentValue);
        //Debug.Log(lastValue);

        if (stats.HungerPoints > lastHungerPoint)
        {
            Debug.Log("HungerIsIncreasing");

            Hunger1.gameObject.SetActive(true);
            Hunger2.gameObject.SetActive(false);
        }
        else if (stats.HungerPoints < lastHungerPoint)
        {
            Debug.Log("HunerIsDecreasing");

            Hunger1.gameObject.SetActive(false);
            Hunger2.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("HungerStayedTheSame");

            Hunger1.gameObject.SetActive(false);
            Hunger2.gameObject.SetActive(false);
        }
        lastHungerPoint = stats.HungerPoints;
    }

    void CleanlinessChecker()
    {

        //Debug.Log(currentValue);
        //Debug.Log(lastValue);

        if (stats.CleanlinessPoints > lastCleanlinessPoint)
        {
            Debug.Log("CleanlinessIsIncreasing");

            Cleanliness1.gameObject.SetActive(true);
            Cleanliness2.gameObject.SetActive(false);
        }
        else if (stats.CleanlinessPoints < lastCleanlinessPoint)
        {
            Debug.Log("CleanlinessIsDecreasing");

            Cleanliness1.gameObject.SetActive(false);
            Cleanliness2.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("StatsStayedTheSame");

            Cleanliness1.gameObject.SetActive(false);
            Cleanliness2.gameObject.SetActive(false);
        }
        lastCleanlinessPoint = stats.CleanlinessPoints;
    }

    void HeatChecker()
    {

        //Debug.Log(currentValue);
        //Debug.Log(lastValue);

        if (stats.HeatPoints > lastHeatPoint)
        {
            Debug.Log("HeatIsIncreasing");

            Heat1.gameObject.SetActive(true);
            Heat2.gameObject.SetActive(false);
        }
        else if (stats.HeatPoints < lastHeatPoint)
        {
            Debug.Log("HeatIsDecreasing");

            Heat1.gameObject.SetActive(false);
            Heat2.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("HeatStayedTheSame");

            Heat1.gameObject.SetActive(false);
            Heat2.gameObject.SetActive(false);
        }
        lastHeatPoint = stats.HeatPoints;
    }

    void TirednessChecker()
    {

        //Debug.Log(currentValue);
        //Debug.Log(lastValue);

        if (stats.TirednessPoints > lastTirednessPoint)
        {
            Debug.Log("TirednessIsIncreasing");

            Tiredness1.gameObject.SetActive(true);
            Tiredness2.gameObject.SetActive(false);
        }
        else if (stats.TirednessPoints < lastTirednessPoint)
        {
            Debug.Log("TirednessIsDecreasing");

            Tiredness1.gameObject.SetActive(false);
            Tiredness2.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("TirednessStayedTheSame");

            Tiredness1.gameObject.SetActive(false);
            Tiredness2.gameObject.SetActive(false);
        }
        lastTirednessPoint = stats.TirednessPoints;

    }

    void MoodChecker()
    {

        //Debug.Log(currentValue);
        //Debug.Log(lastValue);

        if (stats.MoodPoints > lastMoodPoint)
        {
            Debug.Log("MoodIsIncreasing");

            Mood1.gameObject.SetActive(true);
            Mood2.gameObject.SetActive(false);
        }
        else if (stats.MoodPoints < lastMoodPoint)
        {
            Debug.Log("MoodIsDecreasing");

            Mood1.gameObject.SetActive(false);
            Mood2.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("MoodStayedTheSame");

            Mood1.gameObject.SetActive(false);
            Mood2.gameObject.SetActive(false);
        }
        lastMoodPoint = stats.MoodPoints;
    }
}
