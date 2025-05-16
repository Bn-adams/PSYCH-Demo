using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public float woodDropCount = 2;
    public GameObject woodDropPrefab;
    // Start is called before the first frame update
    void Start()
    {
        woodDropPrefab.SetActive(false);    
    }

    // Update is called once per frame
   
    public void DropWood()
    {
        woodDropPrefab.SetActive(true);

        for (int i = 0; i < woodDropCount; i++)
        {
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * 5f;
            dropPosition.y = transform.position.y + 1;
            Instantiate(woodDropPrefab, dropPosition, Quaternion.identity);
        }
    }

    //private void OnDisable()
    //{
    //    DropWood();
    //}
}
