using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facingPlayer : MonoBehaviour {
    public GameObject playerEyes;
    public GameObject smoke;
    public GameObject holePlane;
    public GameObject holeShowing;

    private float timeCounter = 8;
    private AudioSource voiceover;
    private bool startTalking = false;
    int damping = 2;
    // Use this for initialization
    void Start () {
        voiceover = gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

 
        Vector3 lookPos = playerEyes.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        


    }

    void OnTriggerEnter(Collider other)
    {
        if (!startTalking)
        {
            if (other.gameObject.tag == "Player")
            {

                gameObject.GetComponent<Animator>().SetBool("closeEnough", true);

                voiceover.Play();
               // voiceover.time = 4;
                startTalking = true;

            }


        }
        /*
        if (startTalking)
        {
            if (!voiceover.isPlaying)
            {

                smoke.SetActive(true);
                gameObject.GetComponent<Animator>().SetBool("talkingOver", true);
                holeShowing.GetComponent<fall>().holeShowing = true;
                Destroy(gameObject);
            }
        }
        */
    }

    void OnTriggerStay(Collider other)
    {
        if (!startTalking)
        {
            if (!gameObject.GetComponent<Animator>().GetBool("closeEnough"))
            {
                if (other.gameObject.tag == "Player")
                {
                    gameObject.GetComponent<Animator>().SetBool("closeEnough", true);
                    //voiceover.SetScheduledStartTime(4.00);
                    voiceover.Play();
                    //voiceover.time = 4;

                    startTalking = true;
                }
            }
        }

        if (startTalking)
        {
            if (!voiceover.isPlaying)
            {

                smoke.SetActive(true);
                gameObject.GetComponent<Animator>().SetBool("talkingOver", true);
                Time.timeScale = 1;
                timeCounter -= Time.deltaTime;
                if (timeCounter <= 0)
                {
                    holeShowing.GetComponent<fall>().holeShowing = true;
                    Destroy(gameObject);
                    
                    holePlane.SetActive(false);
                }
            }
        }

    }
}
