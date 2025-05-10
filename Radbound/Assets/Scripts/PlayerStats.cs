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

    private float walkCost = 0.5f;


    //Health Varibles
    private float maxHealth = 100;
    private float minHealth = 0;
    private float healthPoints;

    //Thirst Varibles
    private float maxThirst = 100;
    private float minThirst = 0;
    private float thristPoints;

    //Hunger Varibles
    private float maxHunger = 100;
    private float minHunger = 0;
    private float hungerPoints;

    //Cleanliness Varibles
    private float maxCleanliness = 100;
    private float minCleanliness = 0;
    private float cleanlinessPoints;

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

    //Health
    public float MaxHealth { get => maxHealth; set => maxHealth = value; } 
    public float MinHealth { get => minHealth; set => minHealth = value; }
    public float HealthPoints { get => healthPoints; set => healthPoints = value; }
   
    //Thirst
    public float MaxThirst { get => maxThirst; set => maxThirst = value; }
    public float MinThirst { get => minThirst; set => maxThirst = value; }
    public float ThirstPoints { get => thristPoints; set => thristPoints = value; }

    //Hunger
    public float MaxHunger {  get => maxHunger; set => maxHunger = value; }
    public float MinHunger { get => minHunger; set => minHunger = value; } 
    public float HungerPoints { get => hungerPoints; set => hungerPoints = value; }

    //Cleanliness
    public float MaxCleanliness { get => maxCleanliness; set => maxCleanliness = value; }
    public float MinCleanliness { get => minCleanliness; set => minCleanliness = value; }
    public float CleanlinessPoints { get => cleanlinessPoints; set => cleanlinessPoints = value; }
  
    //Mood
    public float MaxMood {  get => maxMood; set => maxMood = value; }
    public float MinMood { get => minMood; set => minMood = value; }
    public float ModPoints { get => moodPoints; set => moodPoints = value; }
    
}
