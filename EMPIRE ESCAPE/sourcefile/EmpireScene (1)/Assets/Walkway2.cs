using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkway2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "enemy")
        {
           Vector3 Target = other.gameObject.GetComponent<EnemyControllerIslandWanimationPatrol>().target;
            other.gameObject.GetComponent<EnemyControllerIslandWanimationPatrol>().agent.isStopped = true; ;
            other.gameObject.GetComponent<EnemyControllerIslandWanimationPatrol>().agent.SetDestination(Target);
            other.gameObject.GetComponent<EnemyControllerIslandWanimationPatrol>().agent.transform.LookAt(Target);//+
        }

    }
}
