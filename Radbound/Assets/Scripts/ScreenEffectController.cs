using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffectController : MonoBehaviour
{
    PlayerStats stats;

    //Screen Effects
    public Image thirst20;
    public Image thirst40;

    public Image hunger20;
    public Image hunger40;

    public Image Cleanliness20;
    public Image Cleanliness40;

   

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

        thirst20.gameObject.SetActive(true);
        thirst40.gameObject.SetActive(false);

        hunger20.gameObject.SetActive(false);
        hunger40.gameObject.SetActive(false);

        Cleanliness20.gameObject.SetActive(false);
        Cleanliness20.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ThirstController();
        HungerController();
        CleanlinessController();
    }


    public void ThirstController()
    {
        if(stats.ThirstPoints < 20f)
        {
            thirst20.gameObject.SetActive(true);
            thirst40.gameObject.SetActive(false);
        }
        else if(stats.ThirstPoints > 40f)
        {
            thirst20.gameObject.SetActive(false);
            thirst40.gameObject.SetActive(true);
        }
        else
        {
            thirst20.gameObject.SetActive(false);
            thirst40.gameObject.SetActive(false);
        }
    }

    public void HungerController()
    {
        if (stats.HungerPoints < 20f)
        {
            hunger20.gameObject.SetActive(true);
            hunger40.gameObject.SetActive(false);
        }
        else if (stats.HungerPoints > 40f)
        {
            hunger20.gameObject.SetActive(false);
            hunger40.gameObject.SetActive(true);
        }
        else
        {
            hunger20.gameObject.SetActive(false);
            hunger40.gameObject.SetActive(false);
        }
    }

    public void CleanlinessController()
    {
        if (stats.CleanlinessPoints < 20f)
        {
            Cleanliness20.gameObject.SetActive(true);
            Cleanliness40.gameObject.SetActive(false);
        }
        else if (stats.CleanlinessPoints > 40f)
        {
            Cleanliness20.gameObject.SetActive(false);
            Cleanliness40.gameObject.SetActive(true);
        }
        else
        {
            Cleanliness20.gameObject.SetActive(false);
            Cleanliness40.gameObject.SetActive(false);
        }
    }
}
