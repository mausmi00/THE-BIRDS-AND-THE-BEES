using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] private GameObject seedPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject spawnedObject = Instantiate(seedPrefab, transform.position, Quaternion.identity);
    }
}
