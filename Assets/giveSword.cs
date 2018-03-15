using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveSword : MonoBehaviour {
    public GameObject sword;
    public bool startLeaving = false;
    public float speed = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(startLeaving)
        {
            gameObject.transform.Translate(-speed*Time.deltaTime,0, 0);
        }
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Sword")
        {
            Destroy(other.gameObject);
            sword.SetActive(true);
            startLeaving = true;
        }
    }
}
