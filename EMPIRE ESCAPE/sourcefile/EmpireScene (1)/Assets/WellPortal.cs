using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellPortal : MonoBehaviour
{

    GameObject playa1;
    public GameObject forcef;
    public AudioSource portalsound;


    // Start is called before the first frame update
    void Start()
    {
        forcef.SetActive(true);
        playa1 = GameObject.Find("ThirdPersonController");
        forcef = GameObject.Find("forcefield");
        forcef.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "Player")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            if (playa1.GetComponent<healthofplayer>().coinbank>=10)
            {

                forcef.SetActive(true);
                portalsound.Play();


            }
            Debug.Log("Instantiate Portal");
            
        }

       
    }







}
