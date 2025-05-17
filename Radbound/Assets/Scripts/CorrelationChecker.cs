using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CorrelationChecker : MonoBehaviour
{
    PlayerStats stats;

    float lastHeatPoint;
    float lastThirstPoint;
    float lastHungerPoint;
    float lastCleanlinessPoint;
    float lastMoodPoint;
    // Start is called before the first frame update
    void Start()
    {

        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

        lastHeatPoint = stats.HeatPoints;
        lastThirstPoint = stats.ThirstPoints;
        lastHungerPoint = stats.HungerPoints;
        lastCleanlinessPoint = stats.CleanlinessPoints;
        lastMoodPoint = stats.MoodPoints;
    }

    // Update is called once per frame
    void Update()
    {

      


        StatChecker(stats.HeatPoints, lastHeatPoint);
        StatChecker(stats.ThirstPoints, lastThirstPoint);
        StatChecker(stats.HungerPoints, lastHungerPoint);
        StatChecker(stats.CleanlinessPoints, lastCleanlinessPoint);
        StatChecker(stats.HeatPoints, lastHeatPoint);
        StatChecker(stats.MoodPoints, lastMoodPoint);
        
    }

    void StatChecker(float currentValue, float lastValue)
    {

        Debug.Log(currentValue);
        Debug.Log(lastValue);

        if (currentValue > lastValue)
        {
            Debug.Log("StatIsIncreasing");
        }
        else if (currentValue < lastValue) 
        {
            Debug.Log("StatIsDecreasing");
        }
        else
        {
            Debug.Log("StatsStayedTheSame");
        }
        

        

    }
}
