using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postTrigger : MonoBehaviour {
    public GameObject shiftTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            shiftTrigger.GetComponent<floorShift>().directionFlag = false;
            Debug.Log("enter postTrigger");
        }

    }
}
