using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class targetpractice : MonoBehaviour
{

    public float health = 60;
    public bool enemydown = false;
    public AudioSource deathsound;
    int diecounter = 0;
    
    public void TakeDamage(float amount)
    {
        health -= amount;


        if (health <= 0f)
        {
            if(diecounter==0)
            {
                Die();
            }

            diecounter = 1;
        }



    }



   public void Die()
    {
        deathsound.Play();
        enemydown = true;
        Destroy(gameObject,2.0f);
        //enemydown = false;
    }


    private void Update()
    {
        //Debug.Log("EnemyHEalth" + health);
    }



}
