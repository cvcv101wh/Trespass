using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject theScene;
    public GameObject gameOverMonitor;
    public GameObject guard;
    private Transform initialPosition;
    //public bool gameOverFlag = false;
    // Use this for initialization
    void Start()
    {
        initialPosition = new GameObject().transform;
        initialPosition.position = new Vector3(1.567f, 0.1094442f, -2.82f) ;
        initialPosition.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(initialPosition);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            theScene.SetActive(true);
            gameObject.SetActive(false);
            gameOverMonitor.GetComponent<fadeOut>().isFadingIn = false;
          //  guard.GetComponent<Animator>().SetBool("Move",false);
            guard.SetActive(true);
            guard.transform.position = initialPosition.position;
            guard.transform.rotation = initialPosition.rotation;
        }

    }
}
