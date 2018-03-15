using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windTrigger : MonoBehaviour
{
    public bool directionFlag = true; // going = true, return = false;
    public GameObject shiftTrigger;
    public GameObject wind;
    // Use this for initialization
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (shiftTrigger.GetComponent<floorShift>().directionFlag)
        {
            if (other.gameObject.tag == "Player")
            {
 
                wind.GetComponent<AudioSource>().Play();
               
                Debug.Log("enter windTrigger");

            }
        }
        else 
        {

            wind.GetComponent<AudioSource>().Stop();

            Debug.Log("enter windTrigger");
        }

    }
    private void OnTriggerExit(Collider other)
    {
       


        
    }
}
