using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeFix : MonoBehaviour
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


    
}
