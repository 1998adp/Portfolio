using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabSpawn;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnObject()
    {
        if (prefabSpawn != null)
        {
            return Instantiate(prefabSpawn, transform.position, Quaternion.identity);
        }
        return null;
    } 
}
