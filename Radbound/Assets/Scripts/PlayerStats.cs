using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Player Varibles
    private float mS = 15;

    private int woodCount = 0;

    //Stamina Varibles
    private float maxStamina = 100;

    private float minStamina = 0;

    private float staminaCount;

    private float attackCost = 5;

    private float walkCost = 3f;

    private float runCost = 9f;


    //Health Varibles
    private float maxHealth = 100;
    private float minHealth = 0;
    private float healthPoints;

    //Thirst Varibles
    private float maxThirst = 100;
    private float minThirst = 0;
    private float thristPoints;
    private float thirstBurn = 0.5f;

    //Hunger Varibles
    private float maxHunger = 100;
    private float minHunger = 0;
    private float hungerPoints;
    private float hungerBurn = 0.25f;

    //Cleanliness Varibles
    private float maxCleanliness = 100;
    private float minCleanliness = 0;
    private float cleanlinessPoints;
    private float inDoorCleanBurn = 0.1f;
    private float outDoorCleanBurn = 0.3f;


    //Heat Varibles
    private float maxHeat = 100;
    private float minHeat = 0;
    private float heatPoints;
    private float movingHeatGen = 1f;
    private float staticHeatGen = 0.1f;
    private float outDoorHeatBurn = 1.5f;
    private float inDoorHeatBurn = 0.1f;

    //Tiredness Varibles
    private float maxTired = 100;
    private float minTired = 0;
    private float tirednessPoints;
    private float energyBurn = 0.5f;

    //Mood Varibles
    private float maxMood = 100;
    private float minMood = 0;
    private float moodPoints;

   

    //Player
    public float MS { get => mS; set => mS = value; }
    public int WoodCount { get => woodCount; set => woodCount = value; }
    
    //Stamina
    public float MaxStamina { get => maxStamina; set => maxStamina = value; }
    public float MinStamina { get => minStamina; set => minStamina = value; }
    public float StaminaCount { get => staminaCount; set => staminaCount = value; }
    public float AttackCost { get => attackCost; set => attackCost = value; }
    public float WalkCost { get => walkCost; set => walkCost = value; }
    public float RunCost { get => runCost; set => runCost = value; }

    //Health
    public float MaxHealth { get => maxHealth; set => maxHealth = value; } 
    public float MinHealth { get => minHealth; set => minHealth = value; }
    public float HealthPoints { get => healthPoints; set => healthPoints = value; }
   
    //Thirst
    public float MaxThirst { get => maxThirst; set => maxThirst = value; }
    public float MinThirst { get => minThirst; set => maxThirst = value; }
    public float ThirstPoints { get => thristPoints; set => thristPoints = value; }
    public float ThirstBurn { get => thirstBurn; set => thirstBurn = value; }


    //Hunger
    public float MaxHunger {  get => maxHunger; set => maxHunger = value; }
    public float MinHunger { get => minHunger; set => minHunger = value; } 
    public float HungerPoints { get => hungerPoints; set => hungerPoints = value; }
    public float HungerBurn { get => hungerBurn; set => hungerBurn = value; }

    //Cleanliness
    public float MaxCleanliness { get => maxCleanliness; set => maxCleanliness = value; }
    public float MinCleanliness { get => minCleanliness; set => minCleanliness = value; }
    public float CleanlinessPoints { get => cleanlinessPoints; set => cleanlinessPoints = value; }
    public float InDoorCleanBurn { get => inDoorCleanBurn; set => inDoorCleanBurn = value; }
    public float OutDoorCleanBurn { get => outDoorCleanBurn; set => outDoorCleanBurn = value; }

    //Heat
    public float MaxHeat { get => maxHeat ; set => maxHeat = value; }
    public float MinHeat { get => minHeat ; set => minHeat = value; }
    public float HeatPoints { get => heatPoints; set => heatPoints = value; }
    public float MovingHeatGen { get => movingHeatGen; set => movingHeatGen = value; }
    public float StaticHeatGen { get => staticHeatGen; set => staticHeatGen = value; }
    public float InDoorHeatBurn { get => inDoorHeatBurn; set => inDoorHeatBurn = value; }
    public float OutDoorHeatBurn { get => outDoorHeatBurn; set => outDoorHeatBurn = value; }

    public float MaxTiredness { get => maxTired; set => maxTired = value; }
    public float MinTiredness { get => minTired; set => minTired = value; }
    public float TirednessPoints { get => tirednessPoints; set => tirednessPoints = value; }
    public float EnegryBurn { get => energyBurn; set => energyBurn = value; }

    //Mood
    public float MaxMood {  get => maxMood; set => maxMood = value; }
    public float MinMood { get => minMood; set => minMood = value; }
    public float MoodPoints { get => moodPoints; set => moodPoints = value; }
    
}
