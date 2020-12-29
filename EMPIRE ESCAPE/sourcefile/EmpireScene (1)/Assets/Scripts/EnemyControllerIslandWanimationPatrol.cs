﻿using UnityEngine.AI;
using UnityEngine;

public class EnemyControllerIslandWanimationPatrol: MonoBehaviour
{


    
   public NavMeshAgent agent;
    Transform player;
    public Vector3 target;
    public Vector3 target2;
    bool enemydead;

    public float rotationSpeed = 10f;

    GameObject targetObject;

    //^&^&^^&^&^&^&^^&^&^
    public Animator anim;

    public AudioSource chasesound;
    int soundcounter = 0;

    //^&^&^^&^&^&^&^^&^&^

    public enum States
    {
        march,
        chasePlayer,
        attack,
        death
    }

    States _state = States.march;
    void Start()
    {
        
        //GameObject tt = GameObject.Find("Castle");
        GameObject tt = GameObject.FindGameObjectWithTag("city");
        GameObject tt2 = GameObject.FindGameObjectWithTag("city2");
        targetObject = tt;
        target = tt.transform.position;
        target2 = tt2.transform.position;

        //^&^&^^&^&^&^&^^&^&^

        anim.SetInteger("State", 0); // idle 0
                                     //^&^&^^&^&^&^&^^&^&^
        agent.SetDestination(target);

       

    }
    void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        ChangeStates();

        switch (_state)
        {
            case States.march: Marching(); break;
            case States.chasePlayer: Chase(); break;
            case States.attack: Attacking(); break;
                
        }
        enemydead = GetComponent<targetpractice>().enemydown;
        Die();

    }

    void ChangeStates()
    {
        float distance = 0;

        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
        }
        else
        {
            _state = States.march;
            return;
        }

        if (distance < 20 && distance > 4)    //if player can be seen, chase the player
        {
           
            switch (_state)
            {
                case States.march:
                    _state = States.chasePlayer;
                    break;
                case States.chasePlayer:
                    break;
                case States.attack:
                    _state = States.chasePlayer; //}{}{}}{{}{}{{}{
                    break;
            }
        }
        else if (distance < 4)   //if the player is close, attack the player
        {

            
            switch (_state)
            {
                case States.march:
                    _state = States.attack;
                    break;
                case States.chasePlayer:
                    _state = States.attack;
                    break;
                case States.attack:
                    break;
            }
        }
        
        else
        {
            //if player is too far, goes into the village
           
            switch (_state)
            {
                case States.march:
                    break;
                case States.chasePlayer:
                    _state = States.march;
                    break;
                case States.attack:
                    _state = States.march;
                    break;
            }
           
        }

    }

    void Marching()
    {
       
         agent.isStopped = false;
        //transform.LookAt(target);
        GetComponent<NavMeshAgent>().speed = 5f; //5f
        anim.SetInteger("State", 4); // ***WALK

        //agent.SetDestination(target);
        

    }

    void Chase()
    {

        if (soundcounter == 0)
        {
            chasesound.Play();
        }

        agent.isStopped = false;
        transform.LookAt(player);
        GetComponent<NavMeshAgent>().speed = 12f;
        if (player)
        {
            
            agent.SetDestination(player.position);
            anim.SetInteger("State", 1); // run
        }
        else
        {
            agent.enabled = false;
        }

        soundcounter = 1;
    }
    void Attacking()
    {
        transform.LookAt(player);
        agent.isStopped = true;
        GetComponent<NavMeshAgent>().speed = 0.3f;

        agent.SetDestination(player.position);
            anim.SetInteger("State", 2); // attack
            //RotateTowards(player);
        
        

    }

    void Die()
    {
        if (enemydead)
        {
            anim.SetInteger("State", 3); //Die animation}
            agent.isStopped = true;

            enemydead = false;
        }
    }

    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }







}

