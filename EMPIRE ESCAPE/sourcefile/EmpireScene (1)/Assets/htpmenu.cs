using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class htpmenu : MonoBehaviour
{
    public GameObject main, htp;
    // Start is called before the first frame update
    void Start()
    {
        main.SetActive(true);
        htp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loadhtp()
    {
        main.SetActive(false);
        htp.SetActive(true);
    }




    public void Loadmain()
    {
        main.SetActive(true);
        htp.SetActive(false);
    }


    public void Backtogame()
    {
        
        htp.SetActive(false);
    }


    public void Ingamemenu()
    {

        htp.SetActive(true);
    }


    public void Loadmainfromgameover()
    {

        SceneManager.LoadScene(0);
        Debug.Log("Scene Loaded");
    }



public void Playagain()
    {


        SceneManager.LoadScene(0);

    }

}
