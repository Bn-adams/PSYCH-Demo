using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wood : MonoBehaviour
{
    PlayerStats stats;
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectWood();

            Destroy(gameObject);
        }
       
    }

    public void CollectWood()
    {
        stats.WoodCount++;
        
    }
}
