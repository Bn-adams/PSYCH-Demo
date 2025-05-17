using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterTaskStarter : MonoBehaviour
{
    public TMP_Text TaskText;

    public GameObject BrokenBathroom;

    public GameObject Toilet;
    public GameObject Shower;
    public GameObject Sink;

    public GameObject Tap;

    private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        Toilet.SetActive(false);
        Shower.SetActive(false);
        Sink.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Tap.activeInHierarchy)
        {
            BrokenBathroom.SetActive(false);
            Toilet.SetActive(true);
            Shower.SetActive(true);
            Sink.SetActive(true);
            TaskText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TaskText.gameObject.SetActive(true);
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
