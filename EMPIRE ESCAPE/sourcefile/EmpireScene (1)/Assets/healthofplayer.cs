using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthofplayer : MonoBehaviour
{
    public Animator anim;
    public Animator tpanim;
    public int health = 100;
    GameObject mainplayer;
    GameObject tpmainplayer;
    public int coinbank;
    bool dead = false;

    public Text TxtCoin;

    public bool heal;
    public AudioSource playerdeath;

    

    /*int quicktext = playa1.GetComponent<healthofplayer>().coinbank;

    coinupdater.GetComponent<Text>().text = quicktext.ToString();*/


    // Start is called before the first frame update
    void Start()
    {
        mainplayer = GameObject.Find("paladin_prop_j_nordstrom (2)");
        anim = mainplayer.GetComponent<Animator>();

       tpmainplayer = GameObject.Find("ThirdPersonController");
        tpanim = tpmainplayer.GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("heal is" + heal);
       
        TxtCoin.text = coinbank.ToString();

        if (health <= 0&&dead==false)
        {
            Debug.Log("Player Dead!!!!!!!!!!!!!!!!!!");
            tpanim.SetInteger("PlayerCombatState",10);
            dead = true;

            StartCoroutine("endsequence");


        }
        
        

        if (heal)
        {
            StartCoroutine("healup");
        }
        
    }


/*
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "ensword")     //   if (col.collider.tag == "enemy" && anim.GetCurrentAnimatorStateInfo(0).IsName("enemysword"))
        {
            if (health>=0)
            {
                Debug.Log("HIT");
                health = health - 10;
            }
           
        }
       
       

    }*/

    /*void OnTriggerEnter(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "sword")

        {
            health = health - 3;
        }


    }*/



    IEnumerator healup()
    {
        health = 100;
        
        yield return new WaitForSeconds(1);
       

        heal = false;

    }

    IEnumerator endsequence()
    {

        playerdeath.Play();
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(2);
        
    }






}
