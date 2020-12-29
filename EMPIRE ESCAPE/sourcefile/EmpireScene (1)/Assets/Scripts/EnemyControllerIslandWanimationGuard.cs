using UnityEngine.AI;
using UnityEngine;

public class EnemyControllerIslandWanimationGuard: MonoBehaviour
{


    
    NavMeshAgent agent;
    Transform player;
    public Vector3 target;

    bool enemydead;

    public float rotationSpeed = 10f;

    GameObject targetObject;

    //^&^&^^&^&^&^&^^&^&^
    public Animator anim;

    GameObject mainplayer;
    Animator manimator;

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

        targetObject = tt;
        target = tt.transform.position;
       
        //^&^&^^&^&^&^&^^&^&^
       
        anim.SetInteger("State", 0); // idle 0
                                     //^&^&^^&^&^&^&^^&^&^

        //@@@@
         mainplayer = GameObject.Find("ThirdPersonController");
        manimator = mainplayer.GetComponent<Animator>();
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



        if (distance < 12 && distance > 2 && !manimator.GetCurrentAnimatorStateInfo(0).IsName("Crouching"))    //if player can be seen, chase the player 20 distance original
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
        else if (distance < 2)   //if the player is close, attack the player
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
         //agent.isStopped = true;
        //transform.LookAt(target);
        //GetComponent<NavMeshAgent>().speed = 10f;
        
        
       // agent.SetDestination(target); not needed 
        //anim.SetInteger("State", 0); // idle

    }

    void Chase()
    {
       
        if(soundcounter==0)
        {
            chasesound.Play();
        }
        
        soundcounter=1;
        agent.isStopped = false;
        transform.LookAt(player);
        GetComponent<NavMeshAgent>().speed = 14f;
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

