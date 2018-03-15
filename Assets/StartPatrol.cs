using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPatrol : MonoBehaviour {
    public GameObject guard1;
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
            guard1.GetComponent<Animator>().SetBool("Move",true);
            guard1.GetComponents<AudioSource>()[0].Play();
        }

    }
}
