using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedboost : MonoBehaviour
{
    public AudioSource speedsound;
    GameObject playa1;
    // Start is called before the first frame update
    void Start()
    {
        playa1 = GameObject.Find("ThirdPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            playa1.GetComponent<combatinteraction>().speedboost=true;
            speedsound.Play();
            Destroy(gameObject, 3.0f);
        }

        
        
    }



  



}
