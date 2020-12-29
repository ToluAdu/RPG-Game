using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        
        {
           
            Debug.Log("Won The Game");
           
            Destroy(theCollision);
            StartCoroutine("Winsequence");
        }

       
    }


    IEnumerator Winsequence()
    {
        
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(3);
    }




}
