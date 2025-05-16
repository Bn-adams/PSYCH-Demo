using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float mushroomDropCount = 2;
    public GameObject mushroomDropPrefab;
    // Start is called before the first frame update
    void Start()
    {
        mushroomDropPrefab.SetActive(false);
    }

    // Update is called once per frame

    public void DropMushroom()
    {
        mushroomDropPrefab.SetActive(true);

        for (int i = 0; i < mushroomDropCount; i++)
        {
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * 5f;
            dropPosition.y = transform.position.y;
            Instantiate(mushroomDropPrefab, dropPosition, Quaternion.identity);
        }
    }
}
