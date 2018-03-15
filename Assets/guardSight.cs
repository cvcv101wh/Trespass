using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardSight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight = false;
    public GameObject eye;
    private AudioSource gameOver;

    private SphereCollider col;
    //private GameObject player;
    // Use this for initialization
    void Start()
    {
        gameOver = GetComponents<AudioSource>()[1];
         //player = GameObject.FindGameObjectWithTag("Player");
         col = GetComponent<SphereCollider>();
        //Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
       // Debug.Log(other);
        //Debug.Log("collide work well");
        // If the player has entered the trigger sphere...
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerHand")
        {
           

            //Debug.Log("collide work well");
            // By default the player is not in sight.
            playerInSight = false;
            
            // Create a vector from the enemy to the player and store the angle between it and forward.
            Vector3 direction = other.transform.position - transform.up - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            Debug.DrawRay(transform.position + transform.up, direction, Color.green);
            // If the angle between forward and where the player is, is less than half the angle of view...
            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;
               // Debug.Log(angle);
                // ... and if a raycast towards the player hits something...
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    //Debug.Log(transform.position + transform.up);
                    // ... and if the raycast hits the player...
                    if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "PlayerHand")
                    {

                        Debug.DrawRay(transform.position + transform.up, direction, Color.red);
                        Debug.Log(gameOver.isPlaying);
                        if(!gameOver.isPlaying)
                        gameOver.Play();
                        // ... the player is in sight.
                        playerInSight = true;
                        eye.GetComponent<fadeOut>().isFadingOut = true;
                        //Destroy(gameObject);
                        // Debug.Log("in sight");
                        // Set the last global sighting is the players current position.
                        //  lastPlayerSighting.position = player.transform.position;
                        //  GetComponents<AudioSource>()[0].Stop();

                    }
                    else
                    {
                        //Debug.Log("not in sight");
                    }
                }
            }
        }
    }
}
