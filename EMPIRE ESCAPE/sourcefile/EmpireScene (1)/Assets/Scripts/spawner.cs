using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{


    Vector3 spawnlocation;

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
             

    // Use this for initialization
    void Start()
    {
       // Vector3 spawnlocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        GameObject localspawnee = spawnee;
       Instantiate(spawnee, transform.position, transform.rotation);








        //Destroy(spawnee, 1.0f);
        /*if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }*/
        
    }


    // Update is called once per frame
    void Update()
    {

    }

}
