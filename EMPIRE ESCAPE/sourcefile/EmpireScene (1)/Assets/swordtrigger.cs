using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordtrigger : MonoBehaviour
{

    GameObject playa1;
    GameObject healthx;
    public AudioSource slashsound;
    // Start is called before the first frame update
    void Start()
    {
        playa1 = GameObject.Find("ThirdPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider theCollision) 
    {
        if (theCollision.gameObject.tag == "Player")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            Debug.Log("TRIGGER HIT");
            
            if (playa1.GetComponent<healthofplayer>().health >= 0)
            {
                playa1.GetComponent<healthofplayer>().health= playa1.GetComponent<healthofplayer>().health - 5;
                playa1.GetComponent<combatinteraction>().m_Animator.SetTrigger("damage"); ;
                Debug.Log("5 damage");
                slashsound.Play();
               // health = health - 10;
            }
        }

       
    }



}
