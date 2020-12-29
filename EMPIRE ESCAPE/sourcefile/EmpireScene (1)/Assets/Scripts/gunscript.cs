using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.red);




        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
        
    }
  void Shoot()
    {
       
        RaycastHit hit;

       if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "OBJECT HIT");

           targetpractice target = hit.transform.GetComponent<targetpractice>();
            if (target != null)
            {
                target.TakeDamage(damage);

            }
            
        }

    }

    
}
