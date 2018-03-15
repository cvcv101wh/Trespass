using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorShift : MonoBehaviour
{
    public GameObject rotatingDoor;
    public bool directionFlag = true; // going = true, return = false;
    public GameObject floor;
    public GameObject target;
    public GameObject [] disappearObjects;
    //public GameObject wind;
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
        if (directionFlag)
        {
            if (other.gameObject.tag == "Player")
            {
                floor.transform.position = target.transform.position;
            //    wind.GetComponent<AudioSource>().Play();
                disappearObjects[0].SetActive(false);
                disappearObjects[1].SetActive(false);
                Debug.Log("enter shiftTrigger");
                disappearObjects[3].SetActive(true);
                disappearObjects[2].SetActive(false);

                rotatingDoor.GetComponent<Animator>().SetTrigger("Return");
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                floor.transform.position = Vector3.zero;
              //  wind.GetComponent<AudioSource>().Stop();
                disappearObjects[0].SetActive(true);
                disappearObjects[1].SetActive(true);
                disappearObjects[1].GetComponent<Animator>().SetBool("Move", true);
                disappearObjects[1].GetComponents<AudioSource>()[0].Play();
                disappearObjects[3].SetActive(false);
                disappearObjects[2].SetActive(true);

                Debug.Log("enter shiftTrigger");
            }
          
        }
    }
}

