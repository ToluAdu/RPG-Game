using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyLockOn : MonoBehaviour
{

    GameObject Player;
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "enemy")
        {
            
            Player.transform.LookAt(other.gameObject.transform);

        }
            

        

    }
















}
