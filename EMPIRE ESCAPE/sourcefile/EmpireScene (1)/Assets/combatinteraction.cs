using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class combatinteraction : MonoBehaviour
{
    GameObject player;
    public Animator m_Animator;
    int combatmethod;
    bool combatsequence = false;
    bool maulinhand = false;
    bool daggerinhand = false;
    bool freeinhand = false;
    public bool speedboost;

   public GameObject effect1, effect2, effect3,effect4;


    public GameObject maul, dagger;
    public GameObject maulprop, daggerprop;
    public GameObject Handsfree, DaggerEquipped, MaulEquipped;


    public AudioSource daggersound,daggercharge, maulsound,maulsound2, kicksound,kickbeam;
    void Start()
    {
         player = GameObject.Find("ThirdPersonController");
       m_Animator = player.GetComponent<Animator>();

        
        freeinhand = true;

        effect1.SetActive(false);
        effect2.SetActive(false);
        effect3.SetActive(false);
        effect4.SetActive(false);



        Handsfree.SetActive(true);
        DaggerEquipped.SetActive(false);
        MaulEquipped.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            freeinhand = true;
            maul.SetActive(false);
            dagger.SetActive(false);
            daggerinhand = false;
           maulinhand = false;

            maulprop.SetActive(true);
            daggerprop.SetActive(true);

            Handsfree.SetActive(true);
            DaggerEquipped.SetActive(false);
            MaulEquipped.SetActive(false);


        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            daggerinhand = true;
            dagger.SetActive(true);
            maul.SetActive(false);
            
            freeinhand = false;
           maulinhand = false;

            maulprop.SetActive(true);
            daggerprop.SetActive(false);


            Handsfree.SetActive(false);
            DaggerEquipped.SetActive(true);
            MaulEquipped.SetActive(false);


        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            maulinhand = true;
            maul.SetActive(true);
            dagger.SetActive(false);
            daggerinhand = false;
            freeinhand = false;

            maulprop.SetActive(false);
            daggerprop.SetActive(true);


            Handsfree.SetActive(false);
            DaggerEquipped.SetActive(false);
            MaulEquipped.SetActive(true);

        }


        if (Input.GetKeyDown(KeyCode.Q))
        {

            m_Animator.SetTrigger("block");
        }

        if (Input.GetMouseButtonDown(1)&&freeinhand)
        {

            m_Animator.SetTrigger("kick");
            //combatsequence = true;
            combatmethod = 1; //kick
           
            StartCoroutine("Effect1");
           
            //3 secs

        }


        if (Input.GetKeyDown(KeyCode.E)&&maulinhand)
        {

            m_Animator.SetTrigger("hit");
            //combatsequence = true;
            combatmethod = 2; //hammer hit
            StartCoroutine("Effect2");

        }

        if (Input.GetKeyDown(KeyCode.R)&&daggerinhand)
        {

            m_Animator.SetTrigger("sword");
            //combatsequence = true;
            combatmethod = 3; //dagger hit
            StartCoroutine("Effect3");

        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {
            combatsequence = false;
            combatmethod = 0;
            //Debug.Log("IS GROUNDED");
            // Avoid any reload.
        }

        if (speedboost)
        {
            
            StartCoroutine("Effect4");
        }



    }

    IEnumerator Effect1()
    {
        kickbeam.Play();
        kicksound.Play();
        effect1.SetActive(true);
        yield return new WaitForSeconds(2);
        effect1.SetActive(false);

    }

    IEnumerator Effect2()
    {
        maulsound.Play();
        effect2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        effect2.SetActive(false);
        maulsound2.Play();

    }

    IEnumerator Effect3()
    {
        daggercharge.Play();
        effect3.SetActive(true);
        yield return new WaitForSeconds(1f);
        effect3.SetActive(false);
        daggercharge.Stop();
        daggersound.Play();

    }


    IEnumerator Effect4()
    {
       
        effect4.SetActive(true);
        player.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = 4f;
        
        yield return new WaitForSeconds(3f);
        effect4.SetActive(false);
      
        player.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = 1.4f;
        speedboost = false;

    }

    void OnCollisionEnter(Collision col)
    {
        /*if (col.gameObject.CompareTag("enemy") && combatsequence)
        {
            //col.getComponent<targetpractice>().Die();
            Debug.Log("Enemy dead");
            col.gameObject.GetComponent<targetpractice>().Die();
        }
*/
        if (col.gameObject.CompareTag("enemy") && combatmethod==1)
        {
            //col.getComponent<targetpractice>().Die();
           // Debug.Log("3 hit kick");

          //  Debug.Log("EnemyHealth"+col.gameObject.GetComponent<targetpractice>().health);
            col.gameObject.GetComponent<targetpractice>().TakeDamage(34);
        }

        if (col.gameObject.CompareTag("enemy") && combatmethod == 2)
        {
            //col.getComponent<targetpractice>().Die();
           // Debug.Log("1 hit hammer");

           //Debug.Log("EnemyHealth" + col.gameObject.GetComponent<targetpractice>().health);
            col.gameObject.GetComponent<targetpractice>().TakeDamage(100);
        }

        if (col.gameObject.CompareTag("enemy") && combatmethod == 3)
        {
            //col.getComponent<targetpractice>().Die();
           // Debug.Log("2 hit dagger");

            //Debug.Log("EnemyHealth" + col.gameObject.GetComponent<targetpractice>().health);
            col.gameObject.GetComponent<targetpractice>().TakeDamage(50);
        }

        //can do int combatmethod if 1 then do this damage if 2 do this etc...
    }










}

