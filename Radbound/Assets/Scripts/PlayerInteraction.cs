using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3;
    Interactable currentInteractable;

    public Transform orientation;


    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if(Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
            Debug.Log("Interacting");
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //Camera.main.transform.forward
        //if colliders with anything within player range
        if (Physics.Raycast(ray, out hit, playerReach))
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

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }

}
