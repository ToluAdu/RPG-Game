using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coincollected : MonoBehaviour
{
    GameObject playa1;
    GameObject coinupdater;
    public AudioSource coinsound;

    // Start is called before the first frame update
    void Start()
    {
        playa1 = GameObject.Find("ThirdPersonController");
        coinupdater = GameObject.Find("coincollected");
        
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
            // coinsound.Play();

            StartCoroutine("PlaySoundAndDestroyAfterwards");
            Debug.Log("coin collected");
            //gameObject.SetActive(false);
            playa1.GetComponent<healthofplayer>().coinbank++;
           
        }
    }




    private IEnumerator PlaySoundAndDestroyAfterwards()
    {
        coinsound.Play();


        /*while (coinsound.isPlaying)
        {
            yield return null;
        }*/
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }


}
