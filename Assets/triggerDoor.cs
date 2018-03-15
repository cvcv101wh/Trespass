using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor : MonoBehaviour {
    public GameObject guard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void stopSound()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public void stopGuard()
    {
        guard.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        
            if (other.gameObject.tag == "PlayerHand")
            {
            gameObject.GetComponent<Animator>().SetTrigger("Trigger");
            }
        
    }
}
