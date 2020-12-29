using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{

    //public GameObject player;
   // private Vector3 offset;



    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    private Vector3 previousPosition;



    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.transform.position;

        

    }

    // Update is called once per frame
    void LateUpdate()
    {
       // transform.position = player.transform.position + offset;

       


    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }



        cam.transform.position = target.position; //new Vector3();

        cam.transform.Translate(new Vector3(x: 1, y: 5, z: -15));


        if (Input.GetMouseButton(0))
         {

            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = target.position; //new Vector3();

            cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: direction.y * 100);
            cam.transform.Rotate(new Vector3(x: 0, y: 1, z: 0), angle: direction.x * 100, relativeTo: Space.World);
            cam.transform.Translate(new Vector3(x: 1, y: 5, z: -15));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }


    }











}
