using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3;
    Interactable currentInteractable;

    PlayerStats stats;

    //Sleep Stuffs
    public GameObject SleepPanel;
    public PlayerController playerController;
    public float sleepCount = 5f;

    //Axe Stuffs
    public GameObject AxeHolder;
    public bool canChop = false;
    public GameObject tree;

    public Interactable lastInteract;


    private void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        SleepPanel.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
       InteractionCheck();
       //ChopChecker();
      
    }
    void InteractionCheck()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            //if (currentInteractable.gameObject.tag == tree.gameObject.tag)
            //{

            //}
            //else
            //{
            //    currentInteractable.Interact();
            //    Debug.Log("Interacting");
            //}


            currentInteractable.Interact();
               Debug.Log("Interacting");
        }
        if (Input.GetMouseButton(0) && AxeHolder.activeInHierarchy && currentInteractable != null)
        {
            Debug.Log("Chopping");
            StartCoroutine(ChopWait());
            //public Interactable lastInteract = currentInteractable;
             
        }
    }

    IEnumerator ChopWait()
    {
        yield return new WaitForSeconds(2);

        if (Input.GetMouseButton(0) && currentInteractable != null)
        {
            currentInteractable.Interact();
            Debug.Log("Chopped");


        }


    }


    //void ChopChecker()
    //{
    //    //CheckChop();
    //    if (Input.GetMouseButton(0) && AxeHolder.activeInHierarchy && currentInteractable != null)
    //    {
    //        currentInteractable.Interact();
    //        Debug.Log("Chopping");
    //    }
    //}

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //Camera.main.transform.forward
        //if colliders with anything within player range
        if (Physics.Raycast(ray, out hit, stats.PlayerReach))
        {
            if(hit.collider.tag == "Interactable") //Check looking at obj has tag
            {
                Interactable newInteraction = hit.collider.GetComponent<Interactable>();

                //if there is a currentinteractable and it is not the new intetactable
                if(currentInteractable && newInteraction != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }

                if (newInteraction.enabled)
                {
                    
                    SetNewCurrentInteractable(newInteraction);
                }
                else //if new iteractable is not enabled
                {
                    DisableCurrentInteractable();
                }
            }
            else //if not interactable
            {
                DisableCurrentInteractable();
            }
        }
        else //if nothing in reach
        {
            DisableCurrentInteractable();
        }

        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
    }


    ////void CheckChop()
    ////{
    ////    RaycastHit hit;
    ////    Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
    ////    Camera.main.transform.forward
    ////    if colliders with anything within player range
    ////    if (Physics.Raycast(ray, out hit, stats.PlayerReach))
    ////    {
    ////        if (hit.collider.tag == "Tree") //Check looking at obj has tag
    ////        {
    ////            Interactable newInteraction = hit.collider.GetComponent<Interactable>();

    ////            if there is a currentinteractable and it is not the new intetactable
    ////            if (currentInteractable && newInteraction != currentInteractable)
    ////            {

    ////                currentInteractable.DisableOutline();
    ////            }

    ////            if (newInteraction.enabled)
    ////            {

    ////                SetNewCurrentChopable(newInteraction);
    ////            }
    ////            else //if new iteractable is not enabled
    ////            {
    ////                DisableCurrentChopable();
    ////            }
    ////        }
    ////        else //if not interactable
    ////        {
    ////            DisableCurrentChopable();
    ////        }
    ////    }
    ////    else //if nothing in reach
    ////    {
    ////        DisableCurrentChopable();
    ////    }

    ////    Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
    ////}



    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(currentInteractable.message);
        
    }

    void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();
        //HUDController.instance.DisableChopText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }

    //void SetNewCurrentChopable(Interactable newInteractable)
    //{
    //    currentInteractable = newInteractable;
    //    currentInteractable.EnableOutline();
    //    HUDController.instance.EnableChopText(currentInteractable.message);
    //}

    //void DisableCurrentChopable()
    //{
        
    //    HUDController.instance.DisableChopText();
    //    if (currentInteractable)
    //    {
    //        currentInteractable.DisableOutline();
    //        currentInteractable = null;
    //    }
    //}





    //public void Sleep()
    //{
    //    SleepPanel.SetActive(true);
    //    playerController.isMovementAllowed = false;

    //    StartCoroutine(SleepThroughNight());


    //}
    //private IEnumerator SleepThroughNight()
    //{
    //    yield return new WaitForSeconds(sleepCount);
    //    SleepPanel.SetActive(false);
    //    playerController.isMovementAllowed = true;

    //    stats.TirednessPoints = stats.MaxTiredness;
    //    stats.CleanlinessPoints += 20f;
    //    stats.ThirstPoints -= 20f;
    //    stats.HungerPoints -= 30f;


    //}



    //public void Shower()
    //{
    //    if (Input.GetKey(KeyCode.F))
    //    {
    //        StartCoroutine(Showering());
    //        DisableCurrentInteractable();
    //    }
    //    else
    //    {
    //        Debug.Log("TooClean");
    //    }
    //}
    //private IEnumerator Showering()
    //{
    //    yield return new WaitForSeconds(3);
    //    if (Input.GetKey(KeyCode.F))
    //    {
    //        stats.CleanlinessPoints = stats.MaxCleanliness;
    //        stats.HungerPoints -= 10f;
    //        stats.TirednessPoints -= 10f;
    //        HUDController.instance.EnableInteractionText(currentInteractable.message);
    //    }



    //}

    //public void Eat()
    //{

    //}

    //public void Drink()
    //{

    //}

    //public void Rest()
    //{

    //}
}
