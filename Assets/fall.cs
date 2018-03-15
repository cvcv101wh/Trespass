using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour {
    public Transform room;
    public float speed = 0.00f;
    public float gravity = 9.8f;
    public bool startFall = false;
    public bool holeShowing = false;
    public GameObject guard;
    public GameObject roofwind;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        if (startFall)
        {
            speed += (gravity * Time.deltaTime);
            if (room.position.y >= -0.13f)
            {
                room.position = new Vector3(0, -0.13f, 0);
            }
            else
                room.Translate(Vector3.up * Time.deltaTime * speed);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (holeShowing)
        {
            if (other.gameObject.tag == "Player")
            {
                startFall = true;
                roofwind.SetActive(false);
                guard.SetActive(true);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (holeShowing)
        {
            if (other.gameObject.tag == "Player")
            {
                startFall = true;
                roofwind.SetActive(false);
                guard.SetActive(true);
            }
        }
    }
}
